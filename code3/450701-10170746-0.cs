    List<FileAttributes> listAttributes = new List<FileAttributes>();
    private void HiddenInvoke(CheckState HiddenState)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Hidden.CheckState = HiddenState;
            });
        }
        private void ReadOnlyInvoke(CheckState ReadOnlyState)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ReadOnly.CheckState = ReadOnlyState;
            });
        }
        private void HiddenCheck(bool check)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Hidden.Checked = check;
            });
        }
        private void ReadOnlyCheck(bool check)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ReadOnly.Checked = check;
            });
        }
    public void Multi()
        {
            try
            {
                long SizeAll = 0;
                int fileCount = 0, folderCount = 0;
                LocInvoke(Loc);
                foreach (ListViewItem item in SelectedItems)
                {
                   // some other calculations..
                    if (client.IsFile(item.ToolTipText))
                        TypeInvoke(++fileCount, folderCount);
                    else if (client.IsFolder(item.ToolTipText))
                        TypeInvoke(fileCount, ++folderCount);
                   // Adding Attributes to a list
                    listAttributes.Add(client.GetAttributeOfPath(item.ToolTipText));
                   //Size Calculation
                    SizeInvoke(CnvrtUnit(SizeAll += client.GetSizeOfPath(item.ToolTipText)));
                }
                Checking();
                Finished("OK", true);
            }
            catch { } //in case user closes the form before it finishes
        }
    private void Checking()
        {
            bool hiddenSet = false;
            bool readonlySet = false;
            for (int i = 1; i < listAttributes.Count; i++)
            {
                if (hiddenSet && readonlySet)   //checks if they already different then there's no need to check again
                    return;
                if (!hiddenSet)
                {
                    if ((listAttributes[i - 1] & FileAttributes.Hidden) == (listAttributes[i] & FileAttributes.Hidden))
                    {
                        HiddenCheck((listAttributes[i] & FileAttributes.Hidden) == FileAttributes.Hidden);
                    }
                    else
                    {
                        HiddenInvoke(CheckState.Indeterminate);
                        hiddenSet = true;
                    }
                }
                if (!readonlySet)
                {
                    if ((listAttributes[i - 1] & FileAttributes.ReadOnly) == (listAttributes[i] & FileAttributes.ReadOnly))
                    {
                        ReadOnlyCheck((listAttributes[i] & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
                    }
                    else
                    {
                        ReadOnlyInvoke(CheckState.Indeterminate);
                        readonlySet = true;
                    }
                }
            }
        }
