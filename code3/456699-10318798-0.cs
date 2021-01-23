    private void RepositoryItemButtonEdit1_Click(object sender, System.EventArgs e)
    {
    	WhateverClass MyData = (WhateverClass)GridView1.GetFocusedRow();
    	Form1 frmEdit = new Form1(MyData);
    	frmEdit.Show();
    }
