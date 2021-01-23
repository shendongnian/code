    UserControl uc = new UserControl();
    string ID = "1";
    string userControl ="UC" + ID + ".ascx";
    uc = LoadControl(userControl) as UserControl;
    PlaceHolder1.Controls.Add(uc); //some place holder to place controls
