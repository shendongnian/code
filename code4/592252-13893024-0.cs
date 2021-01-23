    System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(Server.MapPath("image\\img_tripod.jpg")); // set image 
    
            Font font = new Font("Arial", 20, FontStyle.Italic, GraphicsUnit.Pixel);
    
            Color color = Color.FromArgb(255, 255, 0, 0);
            Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = Graphics.FromImage(bitmap);
    
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
    
    
            graphics.DrawString(watermarkText, font, brush, atpoint, sf);
            graphics.Dispose();
            MemoryStream m = new MemoryStream();
            bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            m.WriteTo(Response.OutputStream);
            m.Dispose();
            base.Dispose();
