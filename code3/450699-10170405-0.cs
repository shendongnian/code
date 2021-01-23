    private void GetAttributes(FileAttributes fAttributes)
    {
        this.Invoke((MethodInvoker)delegate
        {
            if (fAttributes != 0)
            {
                bool hidden = (fAttributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                if (Hidden.Checked != hidden)
					Hidden.CheckState = CheckState.Indeterminate;
                bool readOnly = (fAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
				if (ReadOnly.Checked != readOnly)
					ReadOnly.CheckState = CheckState.Indeterminate;
            }
        });
    }
    public void Multi()
    {
		FileAttributes fAttributes = client.GetAttributeOfPath(item[0].Path)
        this.Invoke((MethodInvoker)delegate
        {
            if (fAttributes != 0)
            {
                Hidden.Checked = (fAttributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                ReadOnly.Checked = (fAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
            }
        });
        for (int i = 1; i < itemCollection.Count; i++)
        {
            GetAttributes(client.GetAttributeOfPath(item[i].Path));
        }
    }
