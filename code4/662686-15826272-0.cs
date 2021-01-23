    //Convert image to b64
                string path = @"E:\Documents and Settings\Ali\Desktop\original.png";
                Image img = Image.FromFile(path);
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    arr = ms.ToArray();
                }
                String b64 = Convert.ToBase64String(arr);//result:/9j/4AAQSkZJRgABAQEA...
                //Get image bytes
                byte[] originalimage= Convert.FromBase64String(b64);
