    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace PrinterChoosenInAcrobat
    {
    class Program
    {
        public const uint WM_GETTEXTLENGTH = 0x000E;
        private const uint WM_GETTEXT = 0x000D;
        // External OS calls
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
            StringBuilder lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wparam,
            IntPtr lparam);
        [DllImport("User32.dll")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName,
        int nMaxCount);
        static void Main(string[] args)
        {
            try
            {
                IntPtr windowHandle = (IntPtr)FindWindow("AcrobatSDIWindow", null);
                string text = GetWindowText(windowHandle);
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            // Don't close before I get to read the results
            Console.WriteLine();
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
        static string GetWindowText(IntPtr hwnd_printDialog_in_Acrobat)
        {
            int comboBoxCount = 0;
            int HWND_PRINTER_NAME = 1;
            List<IntPtr> ChildPtrList = GetChildWindows(hwnd_printDialog_in_Acrobat);
            IntPtr hwnd = IntPtr.Zero;
            for (int i = 0; i < ChildPtrList.Count; i++)
            {
                StringBuilder sClass = new StringBuilder();
                GetClassName(ChildPtrList[i], sClass, 100);
                if (sClass.ToString() == "ComboBox")
                {
                    comboBoxCount++;
                    if (comboBoxCount == HWND_PRINTER_NAME)
                    {
                        hwnd = ChildPtrList[i];
                        break;
                    }
                }
            }
            ChildPtrList.Clear();
            int sSize;
            sSize = (int)SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero) + 1;
            StringBuilder sbTitle = new StringBuilder(sSize);
            SendMessage(hwnd, WM_GETTEXT, (IntPtr)sSize, sbTitle);
            return (sbTitle.ToString());
        }
        #region Code from http://pinvoke.net/default.aspx/user32/EnumChildWindows.html
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        /// <summary>
        /// Returns a list of child windows
        /// </summary>
        /// <param name="parent">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }
        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }
        /// <summary>
        /// Delegate for the EnumChildWindows method
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
        /// <returns>True to continue enumerating, false to bail.</returns>
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        #endregion
    }
    }
