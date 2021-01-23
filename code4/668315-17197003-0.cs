            Image<Bgr, Byte> convert1 = new Image<Bgr, byte>(Change_Im_Size(cam1.ToBitmap(), 270, 190));
            Image<Bgr, Byte> convert2 = new Image<Bgr, byte>(Change_Im_Size(cam2.ToBitmap(), 270, 190));
            pictureBox1.Image = cam1.ToBitmap();
            pictureBox2.Image = cam2.ToBitmap();
            Image<Bgr, Byte>[] frameArray = new Image<Bgr, Byte>[2];
            frameArray[0] = convert1;
            frameArray[1] = convert2;
            using (Stitcher stitcher = new Stitcher(false))
            {
                try
                {
                    Image<Bgr, Byte> result = stitcher.Stitch(frameArray);
                    pictureBox3.Image = result.ToBitmap();
                }
                catch { }
            }
