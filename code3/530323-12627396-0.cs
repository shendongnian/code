    using System;
    using System.Windows.Threading;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Permissions;
    namespace Utilites
    {
    /// <summary>
    /// Emulates the VB6 DoEvents to refresh a window during long running events
    /// </summary>
    public class ScreenEvents
    {
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }
        public static object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
    }
    }
