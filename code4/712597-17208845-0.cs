    private void btnOK_Click(object sender, System.EventArgs e)
    { 
       if (!EnterNewSettings()){
       MessageBoxResult result = MessageBoxResult.None;
       }else{
          Success = true;
          Close();
       }
    }
