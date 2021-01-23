        ColorMatrix cm = new ColorMatrix(new float[][]
                                                    {
                                                        new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                                                        new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                                                        new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                                                        new float[] {0, 0, 0, 1, 0, 0},
                                                        new float[] {0, 0, 0, 0, 1, 0},
                                                        new float[] {0, 0, 0, 0, 0, 1}
                                                    });
        Bitmap BogusBackground = new Bitmap(this.Width, this.Height);
        ImageAttributes imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(cm);
        Graphics g = Graphics.FromImage(BogusBackground);
        g.DrawImage(bg, new Rectangle(0, 0, BogusBackground.Width, BogusBackground.Height),
                    0,0,
                    bg.Width,
                    bg.Height,
                    GraphicsUnit.Pixel, imageAttributes);
        g.Dispose();
