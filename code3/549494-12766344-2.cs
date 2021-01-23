        public void SomeMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileOk += new CancelEventHandler(dialog_FileOk);
            dialog.Filter = "Jpeg files, PDF files, Word files|*.jpg;*.pdf;*.doc;*.docx";
            dialog.ShowDialog();
        }
        void dialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog dialog = sender as  OpenFileDialog;
            var size = new FileInfo(dialog.FileName).Length;
            if (size > 250000)
            {
                MessageBox.Show("File size exceeded");
                e.Cancel = true;
              }
           
        }
