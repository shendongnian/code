    private void btnEncode_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtInFile.Text))
      {
        FileStream fs = new FileStream(txtInFile.Text, 
                                       FileMode.Open, 
                                       FileAccess.Read);
        byte[] filebytes = new byte[fs.Length];
        fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
        string encodedData = 
            Convert.ToBase64String(filebytes,                 
                                   Base64FormattingOptions.InsertLineBreaks);
        txtEncoded.Text = encodedData; 
      }
    }
