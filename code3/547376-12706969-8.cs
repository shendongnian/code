        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                var files = await Task.Run(() => 
                    new DirectoryInfo(System.IO.Path.GetTempPath()).GetFiles()
                );
                foreach (var f in files)
                    this.dataGrid1.Items.Add(f.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown!"); // do proper error handling here...
            }
            finally
            {
                button1.Enabled = true;
            }
        }
