    using (WebClient myWebClient = new WebClient())
                {
                    using (GhostscriptRasterizer rasterizer = new GhostscriptRasterizer())
                    {
                        /* custom switches can be added before the file is opened
                        rasterizer.CustomSwitches.Add("-dPrinted");
                        */
						byte[] buffer = myWebClient.DownloadData(pdfUrl);
                        int bufferSize = 4096;
                        using (var fileStream = System.IO.File.Create("TempPDFolder/" + pdfName, bufferSize, System.IO.FileOptions.DeleteOnClose))
                        {
                            // now use that fileStream to save the pdf stream
                            fileStream.Write(buffer, 0, buffer.Length);
                            rasterizer.Open(fileStream);
                            var image = rasterizer.GetPage(0, 0, 1);
                            var imageURL = "MyCDNpath/Images/" + filename + ".png";
                            _ = UploadFileToS3(image, imageURL);
                        }
					}
				}
