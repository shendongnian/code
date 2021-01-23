    public class MyTreeView : TreeView
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        public MyTreeView() {
            SetWindowTheme(this.Handle, "explorer", null);
        }
    }
