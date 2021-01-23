    private void button1_Click(object sender, RoutedEventArgs e)
        {
        Microsoft.Win32.OpenFileDialog objDialog = new Microsoft.Win32.OpenFileDialog();
        objDialog.Filter = "Only JPG File|*.jpg";
        objDialog.ShowDialog();
        textBox1.Text = objDialog.FileName;
        Uri path = new Uri(textBox1.Text);
        Bitmap bitmap = new Bitmap(path);
        pictureBox1.Image = bitmap;
        // ...
    } 
