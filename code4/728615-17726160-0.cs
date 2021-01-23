        private void textBox1_PreviewDrop(object sender, DragEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string fileName = e.Data.GetData(DataFormats.StringFormat) as string;
                    using (StreamReader s = File.OpenText(fileName))
                    {
                        ((TextBox)sender).Text = s.ReadToEnd();
                    }
                }
            }
            e.Handled = true; //be sure to set this to true
        }
