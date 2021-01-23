                Feed<Video> videoFeed = request.Get<Video>(query);
                
                Thread th = new Thread(new ParameterizedThreadStart( GetImages));
                th.Start(videoFeed);
                int i = 0;
                foreach (Video entry in videoFeed.Entries)
                {
                    string[] info = printVideoEntry(entry).Split(',');
                    string[] row1 = { "", info[0].ToString(), info[1].ToString() };
                    ListViewItem item = new ListViewItem(row1, i++);
                    YoutubeList.Items.Add(item);
                }
                
            }
            void GetImages(object arg)
            {
                Feed<Video> videoFeed = Feed<Video> arg;
                foreach (Video entry in videoFeed.Entries)
                {
                    string[] info = printVideoEntry(entry).Split(',');
                    WebClient wc = new WebClient();
                    wc.DownloadFile(@"http://img.youtube.com/vi/" + info[0].ToString() + "/hqdefault.jpg", info[0].ToString() + ".jpg");
                    ImageAdd(info[0]+".jpg");
                }
            }
            delegate void imageAdder(string imgName);
            void AddImage(string imgName)
            {
                imageListSmall.Images.Add(Bitmap.FromFile(imgName + @".jpg"));
                imageListLarge.Images.Add(Bitmap.FromFile(imgName + @".jpg"));
                listView1.Refresh();
            }
            void ImageAdd(string imgName)
            {
                this.Invoke(new imageAdder(AddImage), new object[] { imgName });
            }
