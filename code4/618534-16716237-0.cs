    using System;
    using System.Runtime.InteropServices;
    namespace NxtTrack
    {    
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vkCode, byte scanCode, int flags, IntPtr extraInfo);
        enum TrackMove
        {
            Previous,Next
        }
        static void Main(string[] args)
        {
            TrackMove trackMove;
            try
            {
                if(args[0].ToLower().Contains("previous"))
                    trackMove = TrackMove.Previous;
                else if(args[0].ToLower().Contains("next"))
                    trackMove = TrackMove.Next;
                else
                {
                    throw new Exception("wrong param");
                }
            }
            catch
            {
                Console.WriteLine("Params needed: Next or Previous");
                return;
            }
            TrackKeys(trackMove);
        }
        private static void TrackKeys(TrackMove trackMove)
        {
            //http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
            byte msg = trackMove == TrackMove.Previous ? (byte)0xB1 : (byte)0xB0;
            keybd_event(msg, 0x45, 0, IntPtr.Zero);
        }
    }
    }
