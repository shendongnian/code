        void CustomizedToolTip_Popup(object sender, PopupEventArgs e)
        {
            DataGridView parent = e.AssociatedControl as DataGridView;
            if (parent.CurrentCell != null)
            {
                if (parent.CurrentCell.ColumnIndex == 2)
                {
                    string path = parent.CurrentCell.Value.ToString();
                    using (System.Drawing.Imaging.Metafile emf = new System.Drawing.Imaging.Metafile(path))
                    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(emf.Width, emf.Height))
                    {
                        bmp.SetResolution(emf.HorizontalResolution, emf.VerticalResolution);
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                        {
                            g.DrawImage(emf,
                                new Rectangle(0, 0, emf.Width, emf.Height),
                                new Rectangle(0, 0, emf.Width, emf.Height),
                                GraphicsUnit.Pixel
                            );
                            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        }
                    }
                }
            }
        }
