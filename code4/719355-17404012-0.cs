    TaxiEntities db = new TaxiEntities();
    int password = int.Parse(txtPassWord.Text);
    bool IsUserPassCorrected = db.tblOperators
                .Any(item => item.UserName.ToLower() == txtUserName.Text.ToLower() 
                          && item.Password == password);
