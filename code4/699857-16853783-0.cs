                            using (System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Black, fontSize * 0.3f))
                            {
                                p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                                g.DrawPath(p, path);
                                g.FillPath(System.Drawing.Brushes.White, path);
                            }
