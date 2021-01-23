    Dispatcher.Invoke(new Action(() =>
                {
                    using (SaveFileDialog fd = new SaveFileDialog())
                    {
                        var json = JsonConvert.SerializeObject(arScene, Formatting.Indented);
    
                        var bytes = UTF8Encoding.UTF8.GetBytes(json); // or any byte array data
    
                        fd.Filter = "JSon files (*.json)|*.json|All files (*.*)|*.*|ARScene (*.ARScene)|*.ARScene";
                        fd.Title = "Save an ARScene File";
                        fd.AutoUpgradeEnabled = true;
                        fd.DefaultExt = "ARScene";
                        fd.OverwritePrompt = false;
                        fd.RestoreDirectory = true;
                        fd.SupportMultiDottedExtensions = true;
                        fd.CreatePrompt = false;
    
                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            if (fd.FileName != "")
                            {
                                FileStream fs = (FileStream)fd.OpenFile();
                                if (fs != null)
                                {
                                    fs.Write(bytes, 0, bytes.Length);
                                    fs.Close();
                                }
    
                            }
                        }
                        fd.Dispose(); // not needed, but save;-)
                    }
    }));
