        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var files = await Task.Factory.StartNew(() => new DirectoryInfo(System.IO.Path.GetTempPath()).GetFiles());
            foreach (var f in files)
                this.dataGrid1.Items.Add(f.Name);
            button1.Enabled = false;
        }
