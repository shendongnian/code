    using System;
    using System.Window;    
    namespace SomeProject
    {
        public partial class MainWindow: Window
        {
            public MainWindow()
            {
                //Get Existing 'WindowChrome' Properties.
                var captionHeight = chrome.CaptionHeight;
                //Set Existing 'WindowChrome' Properties.
                chrome.GlassFrameThickness = new Thickness(2d);
                //Assign a New 'WindowChrome'.
                chrome = new System.Windows.Shell.WindowChrome();
            }
        }
    }
