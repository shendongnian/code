                bmp = new Bitmap(FileName);
                //bmp = new Bitmap(bmp, new System.Drawing.Size(40, 40));
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
                gr.DrawLine(new Pen(Brushes.White, 20), new Point(0, 0), new Point(0, 40));
                gr.DrawLine(new Pen(Brushes.White, 20), new Point(0, 0), new Point(40, 0));
                gr.DrawLine(new Pen(Brushes.White, 20), new Point(0, 40), new Point(40, 40));
                gr.DrawLine(new Pen(Brushes.White, 20), new Point(40, 0), new Point(40, 40));
