         string tnail = "";
      WebClient client = new WebClient();
        using (Image src = Image.FromFile("http://www.example.com/image.jpg"))
                            {
                                using (Bitmap dst = new Bitmap(25, 33))
                                {
                                    using (Graphics g = Graphics.FromImage(dst))
                                    {
                                        g.SmoothingMode = SmoothingMode.HighQuality;
                                        g.InterpolationMode = InterpolationMode.High;
                                        g.DrawImage(src, 0, 0, dst.Width, dst.Height);
                                    }
                                    tnail = tname;
                                    tnail = Path.ChangeExtension(tnail, null);
                                    tnail += "_thumbnail";
                                    tnail = Path.ChangeExtension(tnail, "jpg");
                                    dst.Save(Path.Combine(Server.MapPath(imagepath), tnail), ImageFormat.Jpeg);
                                   
                                }
                            }
