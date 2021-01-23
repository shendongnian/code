    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Automation;
    using WiPFlash;
    using WiPFlash.Components;
    using WiPFlash.Framework;
    using WiPFlash.Util;
    using WiPFlash.Exceptions;
    
    using NUnit.Framework;
    
    namespace MouseRightClick
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application application = new ApplicationLauncher(TimeSpan.Parse("00:00:20"))
                    .LaunchOrRecycle("foo", @"C:\\hg\\wipflash\\Example.PetShop\\bin\\Debug\\Example.PetShop.exe", Assert.Fail);
    
                var window = application.FindWindow("petShopWindow");
                var totalLabel = window.Find<Label>("copyPetContextTarget");
                Mouse mouse = new Mouse();
                mouse.RightClick(totalLabel);
            }
        }
    
        public class Mouse
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
    
            private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            private const int MOUSEEVENTF_RIGHTUP = 0x0010;
            private const int INPUT_MOUSE = 0;
            private const int INPUT_KEYBOARD = 1;
            private const int INPUT_HARDWARE = 2;
    
            public void RightClick<T>(T element) where T : AutomationElementWrapper
            {
                var point = element.Element.GetClickablePoint();
                var processId = element.Element.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty);
                var window = AutomationElement.RootElement.FindFirst(
                    TreeScope.Children,
                    new PropertyCondition(AutomationElement.ProcessIdProperty,
                                          processId));
    
                window.SetFocus();
    
                var x = (int)point.X;
                var y = (int)point.Y;
    
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(x, y);
    
                SendInput(2, new[] {
                    InputFor(MOUSEEVENTF_RIGHTDOWN, x, y),
                    InputFor(MOUSEEVENTF_RIGHTUP, x, y) },
                    Marshal.SizeOf(typeof(INPUT)));
            }
    
            
            private static INPUT InputFor(uint mouseButtonAction, int x, int y)
            {
                var input = new INPUT();
                input.type = INPUT_MOUSE;
                input.u.mi.dwFlags = mouseButtonAction;
                input.u.mi.time = 0;
                input.u.mi.dwExtraInfo = IntPtr.Zero;            
                return input;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public uint mouseData;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct KEYBDINPUT
            {
                public ushort wVk;
                public ushort wScan;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct HARDWAREINPUT
            {
                public uint uMsg;
                public ushort wParamL;
                public ushort wParamH;
            }
    
            [StructLayout(LayoutKind.Explicit)]
            internal struct INPUT_UNION
            {
                [FieldOffset(0)]
                public MOUSEINPUT mi;
                [FieldOffset(0)]
                public KEYBDINPUT ki;
                [FieldOffset(0)]
                public HARDWAREINPUT hi;
            };
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct INPUT
            {
                public int type;
                public INPUT_UNION u;
            }
        }
    
    }
