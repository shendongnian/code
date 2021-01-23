using System;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
namespace Foo.Windows {
  public class MessageReceivedEventArgs : EventArgs {
    private readonly Message _message;
    public MessageReceivedEventArgs( Message message ) {
      _message = message;
    }
    public Message Message {
      get { return _message; }
    }
  }
  public static class MessageEvents {
    private static object _lock = new object();
    private static MessageWindow _window;
    private static IntPtr _windowHandle;
    private static SynchronizationContext _context;
    public static event EventHandler<MessageReceivedEventArgs> MessageReceived;
    public static void WatchMessage( int message ) {
      EnsureInitialized();
      _window.RegisterEventForMessage( message );
    }
    public static IntPtr WindowHandle {
      get {
        EnsureInitialized();
        return _windowHandle;
      }
    }
    private static void EnsureInitialized() {
      lock( _lock ) {
        if( _window == null ) {
          _context = AsyncOperationManager.SynchronizationContext;
          using( ManualResetEvent mre = new ManualResetEvent( false ) ) {
            Thread t = new Thread( (ThreadStart) delegate {
                                                   _window = new MessageWindow();
                                                   _windowHandle = _window.Handle;
                                                   mre.Set();
                                                   Application.Run();
                                                 } );
            t.Name = "MessageEvents message loop";
            t.IsBackground = true;
            t.Start();
            mre.WaitOne();
          }
        }
      }
    }
    private class MessageWindow : Form {
      private ReaderWriterLock _lock = new ReaderWriterLock();
      private Dictionary<int, bool> _messageSet = new Dictionary<int, bool>();
      public void RegisterEventForMessage( int messageID ) {
        _lock.AcquireWriterLock( Timeout.Infinite );
        _messageSet[ messageID ] = true;
        _lock.ReleaseWriterLock();
      }
      protected override void WndProc( ref Message m ) {
        _lock.AcquireReaderLock( Timeout.Infinite );
        bool handleMessage = _messageSet.ContainsKey( m.Msg );
        _lock.ReleaseReaderLock();
        if( handleMessage ) {
          MessageEvents._context.Send( delegate( object state ) {
            EventHandler<MessageReceivedEventArgs> handler = MessageEvents.MessageReceived;
            if( handler != null )
              handler( null, new MessageReceivedEventArgs( (Message)state ) );
          }, m );
        }
        base.WndProc( ref m );
      }
    }
  }
}
For completeness, these are the constants relevant to the device change detection process:
using System;
using System.Runtime.InteropServices;
namespace Foo.Windows {
  internal class NativeMethods {
    /// <summary>
    /// Notifies an application of a change to the hardware configuration of a device or the computer.
    /// </summary>
    public static Int32 WM_DEVICECHANGE = 0x0219;
    /// <summary>
    /// The system broadcasts the DBT_DEVICEARRIVAL device event when a device or piece of media has been inserted and becomes available.
    /// </summary>
    public static Int32 DBT_DEVICEARRIVAL = 0x8000;
    /// <summary>
    /// Serves as a standard header for information related to a device event reported through the WM_DEVICECHANGE message.
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct DEV_BROADCAST_HDR {
      public Int32 dbch_size;
      public Int32 dbch_devicetype;
      public Int32 dbch_reserved;
    }
    public enum DBT_DEVTYP : uint {
      /// <summary>
      /// OEM- or IHV-defined device type.
      /// </summary>
      DBT_DEVTYP_OEM = 0x0000,
      /// <summary>
      /// Logical volume.
      /// </summary>
      DBT_DEVTYP_VOLUME = 0x0002,
      /// <summary>
      /// Port device (serial or parallel).
      /// </summary>
      DBT_DEVTYP_PORT = 0x0003,
      /// <summary>
      /// Class of devices.
      /// </summary>
      DBT_DEVTYP_DEVICEINTERFACE = 0x0005,
      /// <summary>
      /// File system handle.
      /// </summary>
      DBT_DEVTYP_HANDLE = 0x0006
    }
    /// <summary>
    /// Contains information about a OEM-defined device type.
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct DEV_BROADCAST_VOLUME {
      public Int32 dbcv_size;
      public Int32 dbcv_devicetype;
      public Int32 dbcv_reserved;
      public Int32 dbcv_unitmask;
      public Int16 dbcv_flags;
    }
  }
}
Now all you have to do is to register the message you're interested in and handle the event when it happens. These should be the relevant parts for that process:
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Foo.Windows;
namespace Foo.Core {
  class Daemon {
    private static void InternalRun() {
      MessageEvents.WatchMessage( NativeMethods.WM_DEVICECHANGE );
      MessageEvents.MessageReceived += MessageEventsMessageReceived;
    }
    private static void MessageEventsMessageReceived( object sender, MessageReceivedEventArgs e ) {
      // Check if this is a notification regarding a new device.);
      if( e.Message.WParam == (IntPtr)NativeMethods.DBT_DEVICEARRIVAL ) {
        Log.Info( "New device has arrived" );
        // Retrieve the device broadcast header
        NativeMethods.DEV_BROADCAST_HDR deviceBroadcastHeader =
          (NativeMethods.DEV_BROADCAST_HDR)
          Marshal.PtrToStructure( e.Message.LParam, typeof( NativeMethods.DEV_BROADCAST_HDR ) );
        if( (int)NativeMethods.DBT_DEVTYP.DBT_DEVTYP_VOLUME == deviceBroadcastHeader.dbch_devicetype ) {
          Log.Info( "Device type is a volume (good)." );
          NativeMethods.DEV_BROADCAST_VOLUME volumeBroadcast =
            (NativeMethods.DEV_BROADCAST_VOLUME)
            Marshal.PtrToStructure( e.Message.LParam, typeof( NativeMethods.DEV_BROADCAST_VOLUME ) );
          Log.InfoFormat( "Unit masked for new device is: {0}", volumeBroadcast.dbcv_unitmask );
          int driveIndex = 1;
          int bitCount = 1;
          while( bitCount <= 0x2000000 ) {
            driveIndex++;
            bitCount *= 2;
            if( ( bitCount & volumeBroadcast.dbcv_unitmask ) != 0 ) {
              Log.InfoFormat( "Drive index {0} is set in unit mask.", driveIndex );
              Log.InfoFormat( "Device provides drive: {0}:", (char)( driveIndex + 64 ) );
              int index = driveIndex;
              Thread spawnProcessThread = new Thread( () => SpawnDeviceProcess( string.Format( "{0}", (char)( index + 64 ) ) ) );
              spawnProcessThread.Start();
            }
          }
        } else {
          Log.InfoFormat( "Device type is {0} (ignored).", Enum.GetName( typeof( NativeMethods.DBT_DEVTYP ), deviceBroadcastHeader.dbch_devicetype ) );
        }
      }
    }
  }
}
In my project, I was only interested in retrieving the drive letter for inserted USB keys. This code retrieves that drive letter and would then spawn a dedicated handler process for the device.
This was implemented in a C# service. System.Windows.Forms has to be referenced. Should work just fine.
I might be able to get the entire project onto GitHub, but it appears to be very time consuming to properly clean it up. I hope this is sufficient information to be able to replicate the result.
