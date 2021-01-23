            string foto = "http://icons.iconarchive.com/icons/mazenl77/I-like-buttons/64/Style-Config-icon.png";
            string outFile = Path.GetTempFileName(); 
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(foto, outFile);
                if (Path.GetExtension(foto).ToUpper() == ".PNG")
                {
                    string outFile2 = Path.GetTempFileName();
                    using (System.Drawing.Image image1 = System.Drawing.Image.FromFile(outFile))
                    {
                        image1.Save(outFile2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    System.IO.File.Delete(outFile);
                }
            }
