         //  Image blankICard = Image.FromFile(@"C:\Users\admin\Pictures\filename.jpg");
            int width = 500;
            int height = 500;
            Bitmap outputImage = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.SolidBrush b = new SolidBrush(Color.FromArgb(255, 88, 89, 91));
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawRectangle( new Pen(blackBrush) ,new Rectangle(0, 0, width, height));
         //  new Rectangle(new Point(), blankICard.Size), GraphicsUnit.Pixel);
                Font stringFont = new Font("FreightSans Medium", 20, FontStyle.Regular);
                string address = "Address goes here";
                 
                string employeeCode = "Employee Code:12345678";
                int maxWidth = 30;
                SizeF sf = graphics.MeasureString(employeeCode,
                                new Font(new FontFamily("Arial"), 10F), maxWidth);
                graphics.DrawString(address, new Font("FreightSans Medium", 20, FontStyle.Regular), b, new Point(0, 0));
                
                graphics.DrawString(employeeCode,
                                new Font(new FontFamily("Arial"), 10F), Brushes.Black,
                                new RectangleF(new PointF(0, 25), sf),
                                StringFormat.GenericTypographic); 
                
                //graphics.DrawString(, new Font("FreightSans Medium", 26, FontStyle.Regular), b, new Point(10, 20));
            }
