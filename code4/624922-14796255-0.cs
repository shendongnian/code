    [TestFixture]
    public class TenantTests
    {
        // Declaring a dll import is nothing more than copy/pasting the next method declaration in your code. 
        // You can call the method from your own code, that way you can call native 
        // methods, in this case, install a font into windows.
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);
        // This is a unit test sample, which just executes the native method and shows
        // you how to handle the result and get a potential error.
        [Test]
        public void InstallFont()
        {
            // Try install the font.
            var result = AddFontResource(@"C:\MY_FONT_LOCATION\MY_NEW_FONT.TTF");
            var error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                Console.WriteLine(new Win32Exception(error).Message);
            }
        }
    }
