    private void btnDecode_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtOutFile.Text))
      {
        byte[] filebytes = Convert.FromBase64String(txtEncoded.Text);
        FileStream fs = new FileStream(txtOutFile.Text, 
                                       FileMode.CreateNew, 
                                       FileAccess.Write, 
                                       FileShare.None);
        fs.Write(filebytes, 0, filebytes.Length);
        fs.Close(); 
      }
    }
