        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Documents (.txt)|*.txt";
            if (dlg.ShowDialog() == true)
            {
                fileName = dlg.FileName;
                OutputConsole.Text = " ";
                OutputConsole.Text = fileName;
                var output = new List<MyData>();
                try
                {
                    // First line skipped as we do not need headers.
                    foreach (var line in File.ReadAllLines(filename).Skip(1))
                    {
                        output.Add(new MyData(line.Split(",")));
                    }
                    OutputConsole.Text = string.Format("{0} lines read.", output.Lenght);
                }
                catch (System.IO.IOException ex)
                {
                    //let user know there was an error reading file
                }
                // Do something with output
            }
        }
