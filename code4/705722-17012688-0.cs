       private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = "xlsx";
                dlg.Filter = "New Excel(*.xlsx)|*.*";
                var file = FilesSelectedItem;
                
                if (dlg.ShowDialog() ?? false)
                {
                    File.WriteAllBytes(dlg.FileName, file);
                }
            }
        }
