    private void SelectDataSourceClick(object sender, EventArgs e)
    {
        string FilePath;
        string ext;
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Microsoft Access Databases |*.mdb|Excel Workbooks|*.*";
        ofd.Title = "Select the data source";
        ofd.InitialDirectory = ElementConfig.TransferOutPath();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            FilePath = ofd.FileName.ToString();
            var extension = Path.GetExtension(FilePath);
            switch (extension)
            {
                case "xls":
                    MessageBox.Show(FilePath);
                    AccessImport(FilePath);
                    break;
                case "mdb":
                    MessageBox.Show(FilePath);
                    AccessImport(FilePath);
                    break;
                default:
                    MessageBox.Show("Extension not recognized " + extension);
                    break;
            }
        }
        else
        {
            System.Windows.Forms.Application.Exit();
        }
    }
