    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace RichEditor
    {
      public class RichTextBoxEx : RichTextBox
      {
        private IntPtr mHandle = IntPtr.Zero;
    
        protected override CreateParams CreateParams
        {
          get
          {
            //Prevent module being loaded multiple times.
            if (this.mHandle == IntPtr.Zero)
            {
              //load the library to obtain an instance of the RichEdit50 class.
              this.mHandle = LoadLibrary("msftedit.dll");
            }
    
            //If module loaded, reset ClassName.
            if (this.mHandle != IntPtr.Zero)
            {
              CreateParams cParams = base.CreateParams;
    
              // Check Unicode or ANSI system and set appropriate ClassName.
              if (Marshal.SystemDefaultCharSize == 1)
              {
                cParams.ClassName = "RichEdit50A";
              }
              else
              {
                cParams.ClassName = "RichEdit50W";
              }
    
              return cParams;
            }
            else // Module wasnt loaded, return default .NET RichEdit20 CreateParams.
            {
              return base.CreateParams;
            }
          }
        }
    
    
        ~RichTextBoxEx()
        {
          //Free loaded Library.
          if (mHandle != IntPtr.Zero)
          {
            FreeLibrary(mHandle);
          }
        }
    
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(String lpFileName);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);
      }
    }
