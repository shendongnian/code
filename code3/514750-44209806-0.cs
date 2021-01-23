    class Form1 : Form
    {
        readonly PrivateFontCollection _pfc = new PrivateFontCollection();
        public Form1()
        {
            ...
            _pfc.AddFontFile(appPath + @"/font.ttf");
            
            ...
        }
    }
