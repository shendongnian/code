    using System;
    using System.Runtime.InteropServices;
    
    namespace Foreground {
      class GetForegroundWindowTest {
    
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern IntPtr GetForegroundWindow();
    
        public static void Main(string[] args){
            IntPtr fg = GetForegroundWindow(); //use to keep the last active window
            // set the topmost property to your keyboard            
        }
      }
    }
