    protected void _uploadImageBtn_Click(object sender, EventArgs e)
    {
        string extension;
    
        // checks if file exists
        if (!_imageUpload.HasFile)
        {
            _resultLbl.Text = "Please, Select a File!";
            return;
        }
    
        // checks file extension
        extension = System.IO.Path.GetExtension(_imageUpload.FileName).ToLower();
    
        if (!extension.Equals(".jpg") && !extension.Equals(".jpeg") && !extension.Equals(".png"))
        {
            _resultLbl.Text = "Only image files (.JPGs and .PNGs) are allowed.";
            return;
        }
    
        // checks if image dimensions are valid
        if (!ValidateFileDimensions(140, 152))
        {
            _resultLbl.Text = "Maximum allowed dimensions are: width 1520px and height <= 140px.";
            return;
        }
    
        
        byte []input = _imageUpload.FileBytes;
        SqlConnection sqlCn = new SqlConnection("Data Source=localhost;Initial 
                                     Catalog=database;User ID=user;Password=pw");
    
        string qry = "INSERT INTO Project (thumbnail) VALUES (@thumbnail)";
        SqlCommand sqlCom = new SqlCommand(qry, sqlCn);
        sqlCom.Parameters.Add("@thumbnail", SqlDbType.Image, input.Length).Value = input;
        sqlCn.Open();
        sqlCom.ExecuteNonQuery();
        sqlCn.Close();
    }
