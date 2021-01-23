        for (int i = 0; i < lvFiles.Items.Count; i++)
        {
            this.Invoke((MethodInvoker)delegate
            {                        
                lvFiles.EnsureVisible(i);
                lvFiles.Items[i].Selected = true;
                lvFiles.Select();
                filePath = lvFiles.Items[i].Tag.ToString();
            });
            PcapFile pcapFile = new PcapFile();
            pcapFile.sendQueue(filePath, adapter);
            lvFiles.Items[i].Selected = false;
        }
