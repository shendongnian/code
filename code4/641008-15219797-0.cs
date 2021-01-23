      private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select file";
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Jpeg Files(*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.InitialImage = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                    selectedFile = pictureBox1.ImageLocation;
                    selectedFileName = openFileDialog1.SafeFileName;
                    pictureBox1.Load();
    
                }
                
    
            }
    
            public string selectedFileName { get; set; }
    
            public string selectedFile { get; set; }
    
            private void button2_Click(object sender, EventArgs e)
            {
                pictureBox1.ImageLocation = null;
            }
