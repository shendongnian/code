     FileStream outStream = null;
     try
                        {
                            outStream = File.OpenWrite(origFile.ToString());
                                FileInfo destFile = new FileInfo(file.Replace(origDir, destDir));
                                FileInfo destFile1 = new FileInfo(file.Replace(origDir, oldDir));
                                System.IO.File.Copy(origFile.FullName, destFile1.FullName, true);
                                System.IO.File.Copy(origFile.FullName, destFile.FullName, true);
                                File.Delete(origFile.FullName);
                                lblSenast.Text = string.Format("Senaste flytt gjordes {0}",     dateMove.ToString());
                        }
                        catch (IOException exx)
                        {
                            ListViewItem lvi = new ListViewItem(exx.Message);
                            lvFileMoves.Items.Add(lvi);
                            lvi.UseItemStyleForSubItems = true;
                            lvi.ForeColor = Color.Gray;
                        }
                        finally
                        {
                            outStream.Close();
                            outStream.Dispose();
                        }
