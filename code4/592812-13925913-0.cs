    if (EventID == WIA.EventID.wiaEventDeviceConnected)
            {
                Console.WriteLine("Connected: D5100");
            }
            if (EventID == WIA.EventID.wiaEventItemCreated)
            {
                if (d != null)
                {
                    foreach (Property p in d.Properties)
                    {
                        if (p.Name.Equals("Pictures Taken"))
                            Console.WriteLine("Taken");
                    }
                    wiaImageFile = (WIA.ImageFile)(d.Items[d.Items.Count].Transfer(FormatID.wiaFormatJPEG));
                    wiaImageFile.SaveFile(Properties.Settings.Default.FolderNameRaw + "\\" + imageCount + ".jpg");
                    imageCount++;
                }
            }
