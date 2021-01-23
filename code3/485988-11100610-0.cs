        static void Main(string[] args)
        {                        
            BerkeliumSharp.Init(Path.GetTempPath());
            using (Context context = Context.Create())
            {
                BerkeliumSharp.Update();
                using (Window window = new Window(context))
                {
                    string url = "http://www.google.com";
                    window.Resize(500, 500);
                    HandlePaint(window, @"m:\berkelium.png");
                    window.NavigateTo(url);
                    // Give the page some time to update
                    DateTime now = DateTime.Now;
                    while(DateTime.Now.Subtract(now).TotalSeconds < 1)
                        BerkeliumSharp.Update();                   
                }
            }
        }
