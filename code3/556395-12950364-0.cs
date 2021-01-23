        private void browseFolder_Click(object sender, EventArgs e)
        {
            String selectedPath;
            if (ShowFBD(@"C:\", "Please Select a folder", out selectedPath))
            {
                MessageBox.Show(selectedPath);
            }
        }
    public bool ShowFBD(String rootFolder, String title, out String selectedPath)
    {
        var shellType = Type.GetTypeFromProgID("Shell.Application");
        var shell = Activator.CreateInstance(shellType);
        var result = shellType.InvokeMember("BrowseForFolder", BindingFlags.InvokeMethod, null, shell, new object[] { 0, title, 0, rootFolder });
        if (result == null)
        {
            selectedPath = "";
            return false;
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            while (result != null)
            {
                var folderName = result.GetType().InvokeMember("Title", BindingFlags.GetProperty, null, result, null).ToString();
                sb.Insert(0, String.Format(@"{0}\", folderName));
                result = result.GetType().InvokeMember("ParentFolder", BindingFlags.GetProperty, null, result, null);
            }
            selectedPath = sb.ToString();
            selectedPath = Regex.Replace(selectedPath, @"Desktop\\Computer\\.*\(\w:\)\\", rootFolder.Substring(0, 3));
            return true;
        }
    }
