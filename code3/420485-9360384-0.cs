         SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Export in CSV format";
            //decide whether we need to check file exists
            //dlg.CheckFileExists = true;
            //this is the default behaviour
            dlg.CheckPathExists = true;
            //If InitialDirectory is not specified, the default path is My Documents
            //dlg.InitialDirectory = Application.StartupPath;
            dlg.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (dlg.FileName != "")
            //alternative if you prefer this
            //if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK
                //&& dlg.FileName.Length > 0)
            {
                StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                streamWriter.Write("My CSV file\r\n");
                streamWriter.Write(DateTime.Now.ToString());
                //Note streamWriter.NewLine is same as "\r\n"
                streamWriter.Write(streamWriter.NewLine);
                streamWriter.Write("\r\n");
                streamWriter.Write("Column1, Column2\r\n");
                //â€¦
                streamWriter.Close();
            }
            //if no longer needed
            //dlg.Dispose();
