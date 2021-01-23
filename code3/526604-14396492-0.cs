            private Bitmap LoadPicture(string url)
            {
                HttpWebRequest wreq;
                HttpWebResponse wresp;
                Stream mystream;
                Bitmap bmp;
    
                bmp = null;
                mystream = null;
                wresp = null;
                try
                {
                    wreq = (HttpWebRequest)WebRequest.Create(url);
                    wreq.AllowWriteStreamBuffering = true;
    
                    wresp = (HttpWebResponse)wreq.GetResponse();
    
                    if ((mystream = wresp.GetResponseStream()) != null)
                        bmp = new Bitmap(mystream);
                }
                finally
                {
                    if (mystream != null)
                        mystream.Close();
    
                    if (wresp != null)
                        wresp.Close();
                }
                return (bmp);
            }
