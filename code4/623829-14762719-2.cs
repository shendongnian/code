    private void SelectDataSourceClick(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Microsoft Access Databases |*.*|Excel Workbooks|*.xls";
        ofd.Title = "Select the data source";
        ofd.InitialDirectory = ElementConfig.TransferOutPath();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            var FilePath = ofd.FileName.ToString();
            var ext = Path.GetExtension(FilePath).ToLower();
            switch (ext)
            {
                case ".xls":
                    MessageBox.Show(FilePath);
                    AccessImport(FilePath);
                    break;
                case ".mdb":
                    MessageBox.Show(FilePath);
                    AccessImport(FilePath);
                    break;
                default:
                    MessageBox.Show("Extension not recognized " + ext);
                    break;
            }
        }
        else
        {
            System.Windows.Forms.Application.Exit();
        }
    }
