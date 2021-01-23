     WebClient downloader = new WebClient();
     foreach (string[] i in textList)
     {
        try
        {
            String[] fileInfo = i;
            string videoName = fileInfo[0];
            string videoDesc = fileInfo[1];
            string videoAddress = fileInfo[2];
            string imgAddress = fileInfo[3];
            string source = fileInfo[5];
            string folder = folderBuilder(path, videoName);
            string infoFile = folder + '\\' + removeFileType(retrieveFileName(videoAddress)) + @".txt";
            string videoPath = folder + '\\' + retrieveFileName(videoAddress);
            string imgPath = folder + '\\' + retrieveFileName(imgAddress);
            System.IO.Directory.CreateDirectory(folder);
            buildInfo(videoName, videoDesc, source, infoFile);
            textBox1.Text = textBox1.Text + @"begining download of files for" + videoName;
            downloader.DownloadFile(videoAddress, videoPath);
            textBox1.Text = textBox1.Text + @"Complete video for" + videoName;
            downloader.DownloadFile(imgAddress, imgPath);
            textBox1.Text = textBox1.Text + @"Complete img for" + videoName;
        }
        catch(WebException webEx)
        {
           //Check for webEx.Status
        }
        catch(Exception ex)
        {
            //Handle Error. You can log it if you want.
        }
     }
