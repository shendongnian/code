    private FolderBrowserDialog _fbDlg;
    private static string fbd = String.Empty; // Do you really need this?
        public void button2_Click(object sender, EventArgs e)
        {
            _fbDlg = new FolderBrowserDialog();
            _fbDlg.Description = "Select a Folder to save the images.";
            if (_fbDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = _fbDlg.SelectedPath;
        }
    
    public void button3_Click(object sender, EventArgs e)
        {
    
            List<string> address = new List<string>();
            Random r = new Random();
            address.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/4600000_460s.jpg");
            address.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/4600001_460s.jpg");
            address.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/4600002_460s.jpg");
            address.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/4600003_460s.jpg");
            //MessageBox.Show(address[r.Next(0, 4)]);
    
            if (comboBox1.Text == "10")
            {
                string filename = _fbDlg.SelectedPath;
