    public frmEditObject(AddException ObjException)
    {
        InitializeComponent();
        //CHECK THAT YOUR OBJECT IS ALIVE
        if (ObjException != null)
        {
            ListViewItem lviMember, lviSender = null;
            bool alreadyExists = exceptionsList.Find(item => item.UserDetail == ObjException.UserDetail && item.ExceptionType != ObjException.ExceptionType) != null ? true : false;
            if (!alreadyExists)
            {
                 //CHECK THAT NEW ITEM IS REALLY NEW, DOES NOT EXIST IN LIST
                 exceptionsList.Add(ObjException);
                 //YOU DO NOT NEED TO CLEAR LIST AND ADD ALL ITEMS TO IT
                 //lvwExceptionMember.Items.Clear();
                 
                 //lvwExceptionMember.BeginUpdate();
                     Debug.WriteLine(item.ExceptionType);                 
                     if (item.ExceptionType == Enumerations.ExceptionType.Members)
                     {
                          //CHECK DOES YOUR OBJECT HAVE MEMBERS TYPE
                          lviMember = new ListViewItem(item.UserDetail);
                          lviMember.Tag = 0;
                          lviMember.SubItems.Add(GetDisplayNameFromSamAccountName(item.UserDetail));
                          lvwExceptionMember.Items.Add(lviMember);
                     }
                
                // lvwExceptionMember.EndUpdate();
                //lvwExceptionMember.Refresh();
            }
       }
    }
