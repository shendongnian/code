    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(sourceStream);
                    BitmapTransform transform = new BitmapTransform()
                    {
                        ScaledHeight = 900,
                        ScaledWidth = 600
                    };
                    PixelDataProvider pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Rgba8,
                                                                                  BitmapAlphaMode.Straight,
                                                                                  transform,
                                                                                  ExifOrientationMode.RespectExifOrientation,
                                                                                  ColorManagementMode.DoNotColorManage);
                    StorageFile destinationFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(Path.Combine(Database.rootMoviesFoldersPaths, movie.LocalId + ".jpg"));
                    using (var destinationStream = await destinationFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, destinationStream);
                        encoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Premultiplied, 600, 900, 96, 96, pixelData.DetachPixelData());
                        await encoder.FlushAsync();
                        movie.HasFolderImage = true;
                        return true;
                    }
                }
