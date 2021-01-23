    WriteableBitmap wBitmap = new WriteableBitmap(colorFrame.Width,
                                                      colorFrame.Height,
                                                      // Standard DPI
                                                      96, 96,
                                                      // Current format for the ColorImageFormat
                                                      PixelFormats.Bgr32,
                                                      // BitmapPalette
                                                      null);
