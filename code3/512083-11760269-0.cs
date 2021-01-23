    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                var startInfo = new ProcessStartInfo(@"C:\Users\Bodia\Documents\visual studio 2010\Projects\ConsoleApplication8\WindowsFormsApplication1\bin\Debug\WindowsFormsApplication1.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
    
                Console.WriteLine(1);
    
                var process = Process.Start(startInfo);
                Console.WriteLine(2);
    
                Thread.Sleep(400);
                Console.WriteLine(3);
    
                LeftMouseClick(1000, 200);
                Console.WriteLine(4);
            }
    
            static void CursorFun()
            {
                Point cursorPos = new Point();
                GetCursorPos(ref cursorPos);
    
                cursorPos.X += 100;
                Thread.Sleep(1000);
                SetCursorPos(cursorPos.X, cursorPos.Y);
    
                cursorPos.X += 100;
                Thread.Sleep(1000);
                SetCursorPos(cursorPos.X, cursorPos.Y);
    
                cursorPos.X += 100;
                Thread.Sleep(1000);
                SetCursorPos(cursorPos.X, cursorPos.Y);
    
                cursorPos.X += 100;
                Thread.Sleep(1000);
                SetCursorPos(cursorPos.X, cursorPos.Y);
    
            }
    
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int x, int y);
    
            [DllImport("user32.dll")]
            static extern bool GetCursorPos(ref Point lpPoint);
    
            [DllImport("user32.dll")]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    
            public static void LeftMouseClick(int xpos, int ypos) //Make a click at specified coords and return mouse back
            {
                Point retPoint = new Point();
                GetCursorPos(ref retPoint); // set retPoint as mouse current coords
                SetCursorPos(xpos, ypos); //set mouse cursor position
                mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0); //click made
                SetCursorPos(retPoint.X, retPoint.Y); //return mouse position to coords
            }
            struct Point
            {
                public int X;
                public int Y;
            }
    
            private const int MOUSEEVENTF_LEFTDOWN = 0x02;
            private const int MOUSEEVENTF_LEFTUP = 0x04;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            private const int MOUSEEVENTF_RIGHTUP = 0x10;
        }
    }
