            var imageBit = default(byte[]);
            var image = System.Drawing.Image.FromFile(fileName);
            using (var memoryStream = new MemoryStream()) {
                image.Save(memoryStream, ImageFormat.Png);
                imageBit = memoryStream.ToArray();
            }
            var print = new PrintOperation();
            print.BeginPrint += (obj, a) => { print.NPages = 1; };
            print.DrawPage += (obj, a) => {
                                    using (PrintContext context = a.Context) {
                                        using (var pixBuf = new Gdk.Pixbuf(imageBit, image.Width, image.Height)) {
                                            Cairo.Context cr = context.CairoContext;
                                            cr.MoveTo(0, 0);
                                            Gdk.CairoHelper.SetSourcePixbuf(cr, pixBuf, image.Width, image.Height);
                                            cr.Paint();
                                            ((IDisposable) cr).Dispose();
                                        }
                                    }
                                };
            print.EndPrint += (obj, a) => { };
            print.Run(PrintOperationAction.Print, null);
