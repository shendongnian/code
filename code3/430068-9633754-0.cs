    Bitmap result = menu.Draw(bos, new Point(Cursor.Position.X - Left, Cursor.Position.Y - Top), (int)DateTime.Now.Subtract(sabit).TotalMilliseconds / 4);
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = (Image)result.Clone();
            result.Dispose();
