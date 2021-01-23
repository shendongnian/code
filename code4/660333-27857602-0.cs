		//save the text value of txtFolderName into a local variable before run the backgroundworker. 
		string strFolderName;
        private void btnExe_Click(object sender, EventArgs e)
        {
			strFolderName = txtFolderName.text;
			backgroundworker.RunWorkerAsync();
		}
		
		private void backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
			backgroundworkerMethod(strFolderName);//get the value from strFolderName
			...
		}
		
		----------------------------------------------------
		private void btnExe_Click(object sender, EventArgs e)
        {
			backgroundworker.RunWorkerAsync(txtFolderName.text);//pass the value into backgroundworker as parameter/argument
		}
		
		private void backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
			backgroundworkerMethod(e.Argument.ToString());//get the value from event argument
			...
		}
		
