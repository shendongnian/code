            OpenFileDialog browser = new OpenFileDialog();
            browser.AddExtension = true;
            browser.Filter = "Audio, Video File | *.wma; *.mp3; *.wmv";
            browser.Title = "Choose your file";
            string FileName;
            bool? res = browser.ShowDialog(); // No exception thrown here
            if (res ?? false)
            {
                try
                {
                     FileName = browser.FileName;
                    //MyMedia.Source = new Uri(FileName);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
