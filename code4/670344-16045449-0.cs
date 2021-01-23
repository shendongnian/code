        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            dlg.SelectedPath = path;
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = dlg.SelectedPath;
                string pattern = "*.*";
                //OLD CODE                
                //new Model.DirectorySearchModel().Search(path, pattern);
                //SUGGESTION
                (this.DataContext AS DirectorySearchModel).Search(path, pattern);
                Action<string, string> proc = (this.DataContext AS DirectorySearchModel).Search;
                cbResult = proc.BeginInvoke(path, pattern, null, null);
            }
        }
