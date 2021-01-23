    static void Main()
    {
        // Leave these lines here!
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // change this in order to use the webkit control
        Control ctrl = new Button { Width = 100, Height = 23, Text = "abc" };
        using (Bitmap bitmap = new Bitmap(ctrl.Width, ctrl.Height, PixelFormat.Format32bppRgb))
        {
            ctrl.DrawToBitmap(bitmap, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
            bitmap.Save("test.png");
        }
    }
