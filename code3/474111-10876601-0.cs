    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Reflection;
    
    namespace suryakiran
    {
        internal static partial class Extensions
        {
            internal static byte[] AudioCaptcha(this string text)
            {
                String en = "abcdefghijkoprstvx0123456789", Location = string.Concat(System.Web.HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToString(), @"\bin\wav\");
                Int32 dataLength = 0, length = 0, sampleRate = 0, plus = 37500, p = 0;
                Int16 bitsPerSample = 0, channels = 0;
                Byte[] music, wav;
                Random r = new Random();
                p = r.Next(1, 4000000);
                p += (p % 150) + 44;
                Byte[] rb = new Byte[9 * plus];
            // read music
            using (FileStream fs = new FileStream(String.Format(Location + @"z{0}.wav", (r.Next() % 12) + 1), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                wav = new Byte[44];
                fs.Read(wav, 0, 44);
                fs.Position = (long)p;
                fs.Read(rb, 0, rb.Length);
            }
            // make music
            using (MemoryStream ms = new MemoryStream())
            {
                channels = BitConverter.ToInt16(wav, 22); sampleRate = BitConverter.ToInt32(wav, 24); bitsPerSample = BitConverter.ToInt16(wav, 34);
                length = rb.Length; dataLength = rb.Length;
                ms.Write(new Byte[44], 0, 44); ms.Write(rb, 0, rb.Length);
                ms.Position = 0;
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(new char[4] { 'R', 'I', 'F', 'F' }); bw.Write(length);
                    bw.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                    bw.Write((Int32)16); bw.Write((Int16)1);
                    bw.Write(channels); bw.Write(sampleRate);
                    bw.Write((Int32)(sampleRate * ((bitsPerSample * channels) / 8)));
                    bw.Write((Int16)((bitsPerSample * channels) / 8));
                    bw.Write(bitsPerSample); bw.Write(new char[4] { 'd', 'a', 't', 'a' }); bw.Write(dataLength);
                    music = ms.ToArray();
                    p = 0;
                }
            }
            using (MemoryStream final = new MemoryStream())
            {
                final.Write(music, 0, 44);
                // make voice
                using (MemoryStream msvoice = new MemoryStream())
                {
                    msvoice.Write(new Byte[plus / 2], 0, plus / 2);
                    length += plus; dataLength += plus / 2; p += plus / 2;
                    for (var i = 0; i < text.Length; i++)
                    {
                        String fn = String.Format(Location + @"{0}\{1}.wav", (r.Next() % 3), en.Substring(en.IndexOf(text.Substring(i, 1)), 1)).Replace("?", "qm");
                        wav = File.ReadAllBytes(fn);
                        Int32 size = BitConverter.ToInt32(wav, 4);
                        {
                            msvoice.Write(new Byte[plus / 2], 0, plus / 2);
                            length += plus; dataLength += plus / 2; p += plus / 2;
                        }
                        msvoice.Write(wav, 44, wav.Length - 44);
                        length += size; dataLength += size - 36;
                    }
                    msvoice.Position = 0;
                    MemoryStream msmusic = new MemoryStream();
                    msmusic.Write(music, 0, music.Length);
                    msmusic.Position = 44;
                    //merge;
                    while (final.Length < msmusic.Length)
                        final.WriteByte((byte)(msvoice.ReadByte() - msmusic.ReadByte()));
                    return final.ToArray();
                }
            }
        }
        internal static Byte[] VisualCaptcha(this String source)
        {
            try
            {
                Random r = new Random();
                Int32 w = 250, h = 75;
                String family = "Arial Rounded MT Bold";
                using (var bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb))
                {
                    Int32 m = 0, nm = 0;
                    Color tc;
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.Clear(Color.White);
                        SizeF size;
                        m = r.Next() % 9 + 1;
                        nm = r.Next() % 3;
                        tc = Color.FromArgb(255, 255, 255);
                        size = g.MeasureString(source, new Font(family, h * 1.2f, FontStyle.Bold), new SizeF(w * 1F, h * 1F));
                        using (var brush = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.Black, Color.Black, 45, false))
                        {
                            ColorBlend blend = new ColorBlend(6);
                            for (var i = 0; i < 6; i++) { blend.Positions[i] = i * (1 / 5F); blend.Colors[i] = r.RandomColor(255, 64, 128); }
                            brush.InterpolationColors = blend;
                            for (int wave = 0; wave < 2; wave++)
                            {
                                Int32 min = (15 + wave * 20);
                                PointF[] pt = new PointF[] { new PointF(16f, (float)r.Next(min, min + 10)), new PointF(240f, (float)r.Next(min + 10, min + 20)) };
                                List<PointF> PointList = new List<PointF>();
                                float curDist = 0, distance = 0;
                                for (int i = 0; i < pt.Length - 1; i++)
                                {
                                    PointF ptA = pt[i], ptB = pt[i + 1];
                                    float deltaX = ptB.X - ptA.X, deltaY = ptB.Y - ptA.Y;
                                    curDist = 0;
                                    distance = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                                    while (curDist < distance)
                                    {
                                        curDist++;
                                        float offsetX = (float)((double)curDist / (double)distance * (double)deltaX);
                                        float offsetY = (float)((double)curDist / (double)distance * (double)deltaY);
                                        PointList.Add(new PointF(ptA.X + offsetX, ptA.Y + offsetY));
                                    }
                                }
                                for (int i = 0; i < PointList.Count - 24; i = i + 24)
                                {
                                    float x1 = PointList[i].X, y1 = PointList[i].Y, x2 = PointList[i + 24].X, y2 = PointList[i + 24].Y;
                                    float angle = (float)((Math.Atan2(y2 - y1, x2 - x1) * 180 / 3.14159265));
                                    g.TranslateTransform(x1, y1);
                                    g.RotateTransform(angle);
                                    Int32 pm = r.Next() % 2 + 1;
                                    Point[] p1 = new Point[] { new Point(0, 0), new Point(3, -3 * pm), new Point(6, -4 * pm), new Point(9, -3 * pm), new Point(12, 0), new Point(15, 3 * pm), new Point(18, 4 * pm), new Point(21, 3 * pm), new Point(24, 0) };
                                    using (var path = new GraphicsPath()) g.DrawLines(new Pen(brush, 2f), p1);
                                    g.RotateTransform(-angle);
                                    g.TranslateTransform(-x1, -y1);
                                }
                            }
                            using (var path = new GraphicsPath())
                            {
                                PointF[] points = new PointF[] { };
                                if (m == 1 || m == 2 || m == 3) // star trek inverse
                                {
                                    path.AddString(source, new FontFamily(family), 1, h * 0.75F, new PointF((w - size.Width) / 2F, (h * 0.9F - size.Height) / 2F), StringFormat.GenericTypographic);
                                    points = new PointF[] { new PointF(0, 0), new PointF(w, 0), new PointF(w * 0.2F, h), new PointF(w * 0.8F, h) };
                                }
                                else if (m == 4 || m == 5) // star trek
                                {
                                    path.AddString(source, new FontFamily(family), 1, h * 0.75F, new PointF((w - size.Width) / 2F, (h * 1.2F - size.Height) / 2F + 2F), StringFormat.GenericTypographic);
                                    points = new PointF[] { new PointF(w * 0.2F, 0), new PointF(w * 0.8F, 0), new PointF(0, h), new PointF(w, h) };
                                }
                                else if (m == 6 || m == 7) // grow from left
                                {
                                    path.AddString(source, new FontFamily(family), 1, h * 0.75F, new PointF((w * 1.15F - size.Width) / 2F, (h - size.Height) / 2F), StringFormat.GenericTypographic);
                                    points = new PointF[] { new PointF(0, h * 0.25F), new PointF(w, 0), new PointF(0, h * 0.75F), new PointF(w, h) };
                                }
                                else if (m == 8 || m == 9) // grow from right
                                {
                                    path.AddString(source, new FontFamily(family), 1, h * 0.75F, new PointF((w * 0.85F - size.Width) / 2F, (h - size.Height) / 2F), StringFormat.GenericTypographic);
                                    points = new PointF[] { new PointF(w * 0.1F, 0), new PointF(w * 0.9F, h * 0.25F), new PointF(w * 0.1F, h), new PointF(w * 0.9F, h * 0.75F) };
                                }
                                path.Warp(points, new RectangleF(0, 0, w, h));
                                g.FillPath(Brushes.White, path);
                                g.DrawPath(new Pen(brush, 2F), path);
                            }
                        }
                    }
                    using (var thumb = new Bitmap(128, 40, PixelFormat.Format32bppArgb))
                    {
                        using (var g = Graphics.FromImage(thumb))
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Rectangle tr = new Rectangle(0, 0, thumb.Width, thumb.Height);
                            g.DrawImage(bmp, tr);
                            g.DrawRectangle(new Pen(Brushes.White), new Rectangle(0, 0, 127, 39));
                        }
                        using (var ms = new MemoryStream())
                        {
                            ((Image)thumb).Save(ms, ImageFormat.Png);
                            return ms.ToArray();
                        }
                    }
                }
            }
            catch { return null; }
        }
        private static Color RandomColor(this Random rnd, Int32 alpha, Int32 min, Int32 max)
        {
            return Color.FromArgb(alpha, rnd.Next(min, max), rnd.Next(min, max), rnd.Next(min, max));
        }
    }
