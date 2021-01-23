            using (FileStream fs = new FileStream(name, FileMode.Create, FileAccess.Write))
            {
                    byte[] rawData = new byte[fileSize];
                    data.GetBytes(data.GetOrdinal("file"), 0, rawData, 0, fileSize);
                    fs.Write(rawData, 0, fileSize);
            }
            using (var bmpTemp = new Bitmap(name))
            {
                pictureBoxPictADUStudent.BackgroundImage= new Bitmap(bmpTemp);
            } 
