    using (WebClient myWebClient = new WebClient())
                {
                    using (GhostscriptRasterizer rasterizer = new GhostscriptRasterizer())
                    {
                        /* custom switches can be added before the file is opened
                        rasterizer.CustomSwitches.Add("-dPrinted");
                        */
						byte[] buffer = myWebClient.DownloadData(pdfUrl);
						using (var ms = new MemoryStream(buffer))
                        {
                            rasterizer.Open(ms);
                            var image = rasterizer.GetPage(0, 0, 1);
                            var imageURL = "MyCDNpath/Images/" + filename + ".png";
                            _ = UploadFileToS3(image, imageURL);
                        }
					}
				}
