     Bitmap orig = (Bitmap)pictureBox1.Image;
                Bitmap clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (Graphics gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
              }
                FiltersSequence commonSeq = new FiltersSequence();
                commonSeq.Add(Grayscale.CommonAlgorithms.BT709);
                commonSeq.Add(new BradleyLocalThresholding());
                commonSeq.Add(new DifferenceEdgeDetector());
                Bitmap temp = commonSeq.Apply(clone);
