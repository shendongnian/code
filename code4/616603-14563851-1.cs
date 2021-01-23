    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class DatePickerWithWeekNumbers : DateTimePicker
    {
        [DllImport("User32.dll")]
        private static extern int GetWindowLong(IntPtr handleToWindow, 
                                                int offsetToValueToGet);
        [DllImport("User32.dll")]
        private static extern int SetWindowLong(IntPtr h, 
                                                int index, 
                                                int value);
        private const int McmFirst = 0x1000;
        private const int McmGetminreqrect = (McmFirst + 9);
        private const int McsWeeknumbers = 0x4;
        private const int DtmFirst = 0x1000;
        private const int DtmGetmonthcal = (DtmFirst + 8);
        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr h,
                                                 int msg, 
                                                 int param, 
                                                 int data);
        [DllImport("User32.dll")]
        private static extern IntPtr GetParent(IntPtr h);
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr h, 
                                              int msg,
                                              int param, 
                                              ref Rectangle data);
        [DllImport("User32.dll")]
        private static extern int MoveWindow(IntPtr h, 
                                             int x, 
                                             int y,
                                             int width, 
                                             int height, 
                                             bool repaint);
        [Browsable(true), DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public bool DisplayWeekNumbers { get; set; }
        protected override void OnDropDown(EventArgs e)
        {
            // Hex value to specify that we want the style-attributes
            // for the window:
            const int offsetToGetWindowsStyles = (-16);
            IntPtr pointerToCalenderWindow = SendMessage(Handle, 
                                                         DtmGetmonthcal,  
                                                         0,  
                                                         0);
            int styleForWindow = GetWindowLong(pointerToCalenderWindow, 
                                               offsetToGetWindowsStyles);
            // Check properties for the control - matches available 
            // property in the graphical properties for the DateTimePicker:
            if (DisplayWeekNumbers)
            {
                styleForWindow = styleForWindow | McsWeeknumbers;
            }
            else
            {
                styleForWindow = styleForWindow & ~McsWeeknumbers;
            }
            // Get the size needed to display the calendar (inner window)
            var rect = new Rectangle();
            SendMessage(pointerToCalenderWindow, McmGetminreqrect, 0, ref rect);
            // Add to size as needed (I don't know why 
            // this was not correct initially!)
            rect.Width = rect.Width + 28;
            rect.Height = rect.Height + 6;
            // Set window styles..
            SetWindowLong(pointerToCalenderWindow, 
                          offsetToGetWindowsStyles, 
                          styleForWindow);
            
            // Dont move the window - just resize it as needed:
            MoveWindow(pointerToCalenderWindow, 
                       0, 
                       0, 
                       rect.Right, 
                       rect.Bottom, 
                       true);
            // Now access the parrent window..
            var parentWindow = GetParent(pointerToCalenderWindow);
            // ...and resize that the same way:
            MoveWindow(parentWindow, 0, 0, rect.Right, rect.Bottom, true);
            base.OnDropDown(e);
        }
    }
