    using (ManualResetEvent wordQuitEvent = new ManualResetEvent(false))
    {
        Word.Application app = new Word.Application();
        try
        {
            ((Word.ApplicationEvents3_Event)app).Quit += () =>
            {
                wordQuitEvent.Set();
            };
            app.Visible = true;
                
            // Perform automation on Word application here.
            // Wait until the Word application is closed.
            wordQuitEvent.WaitOne();
        }
        finally
        {
            Marshal.ReleaseComObject(app);
        }
    }
