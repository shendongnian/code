    using System;
    using System.Runtime.InteropServices;
         
    public class CapsLockControl
    {
        
        public const byte VK_NUMLOCK = 0x90;
        public const byte VK_CAPSLOCK = 0x14;
        
        [DllImport("user32.dll")]
            static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
         
        public static void Main()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                Console.WriteLine("Caps Lock key is ON.  We'll turn it off");
                keybd_event(CapsLockControl.VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr) 0);
                keybd_event(CapsLockControl.VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                    (UIntPtr) 0);
            }
            else
            {
                Console.WriteLine("Caps Lock key is OFF");
            }
        }
    }
