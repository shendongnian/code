    for(int i=0;i<10;i++){
    var lblProjectName = new Lable();
    lblProjectName.Text = "test";
    lblProjectName.Anchor = AnchorStyles.Left;
    var btnProject = new Button();
    btnProject.Text = "Fill In";
    
    tlpProject.Controls.Add(lblProjectName, 0, i);
    tlpProject.Controls.Add(btnProject, 1, i);
    }
