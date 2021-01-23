                            BlobCounterBase bc = new BlobCounter();
                        bc.FilterBlobs = true;
                        bc.MinHeight = 5;
                        bc.MinWidth = 5;
                        bc.ProcessImage(numberplate);
                        Blob[] blobs = bc.GetObjectsInformation();
                        MessageBox.Show(bc.ObjectsCount.ToString());
                        for (int i = 0, n = blobs.Length; i < n; i++)
                        {
                            if (blobs.Length > 0)
                            {
                                bc.ExtractBlobsImage(numberplate, blobs[i], true);
                                Bitmap copy = blobs[i].Image.ToManagedImage();
                                pictureBox2.Image = numberplate;
                                pictureBox2.Refresh();
                            }
                        }
