        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // This will run whatever file name the user double-clicked
            System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());
        }
