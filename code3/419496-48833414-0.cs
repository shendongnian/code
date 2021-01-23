    using System;
    using System.Runtime.InteropServices;
    public class DateTimePickerHelper {
        const int GDT_VALID = 0;
        const int DTM_SETSYSTEMTIME = (0x1000 + 2);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct SYSTEMTIME {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, 
            int wParam, SYSTEMTIME lParam);
        public static void SetDate(IntPtr handle, DateTime date) {
            var value = new SYSTEMTIME() {
                wYear = (short)date.Year,
                wMonth = (short)date.Month,
                wDayOfWeek = (short)date.DayOfWeek,
                wDay = (short)date.Day,
                wHour = (short)date.Hour,
                wMinute = (short)date.Minute,
                wSecond = (short)date.Second,
                wMilliseconds = 0
            };
            SendMessage(handle, DTM_SETSYSTEMTIME, 0, value);
        }
    }
