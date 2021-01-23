        private void ReverseControlZIndex(Control parentControl)
        {
            var list = new List<Control>();
            foreach (Control i in parentControl.Controls)
            {
                list.Add(i);
            }
            var total = list.Count;
            for (int i = 0; i < total / 2; i++)
            {
                var left = parentControl.Controls.GetChildIndex( list[i]);
                var right = parentControl.Controls.GetChildIndex(list[total - 1 - i]);
                parentControl.Controls.SetChildIndex(list[i], right);
                parentControl.Controls.SetChildIndex(list[total - 1 - i], left);
            }                        
        }
        private void SaveImage()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                int width = pnlCanvas.Size.Width;
                int height = pnlCanvas.Size.Height;
                Bitmap bm = new Bitmap(width, height);
                SuspendLayout();
                // reverse control z-index
                ReverseControlZIndex(pnlCanvas);
                pnlCanvas.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                // reverse control z-index back
                ReverseControlZIndex(pnlCanvas);
                ResumeLayout(true);
                bm.Save(sf.FileName, ImageFormat.Bmp);
            }
        }
