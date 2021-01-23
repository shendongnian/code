    if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        // Read the files
        for (int i = 0; i < openFile.FileNames.Count; i++ )
        {
            var file = openFile.FileNames[i];
            if (file.Contains("Unknown Album") && file  != "Unknown Album")
            {
                openFile.FileNames[i] = file.Replace("Unknown Album", string.Empty);
            }
        }
    }
