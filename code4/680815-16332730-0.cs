            string imageFile = @"c:\image.jpg";
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.DownloadFile("http://www.somewebsite.com/someimage.jpg", imageFile);
            }
