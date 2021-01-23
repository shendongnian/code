     private const int WM_SYSCOMMAND = 0x112;
     private const int MF_BYCOMMAND = 0x00000000;
     private const int SC_SIZE = 0xF000 ;
    [DllImport("user32.dll")]
            private static extern int GetSystemMenu(int hwnd, int bRevert);
    [DllImport("user32.dll")]
            private static extern bool DeleteMenu(int hMenu, int uPosition, int uFlags);
    
    int menu = GetSystemMenu(this.Handle.ToInt32(), 0);
    DeleteMenu(menu, SC_SIZE, MF_BYCOMMAND);
