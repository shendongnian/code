    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    protected override void WndProc(ref Message m)
    {
        switch(m.Msg)
        {
             case 0x201:
               //left button down
               break;
              case 0x202:
               clickedHappened(); //left button up, ie. a click
               break;
             case 0x203:
               //left button double click
               break;
        }
    
        base.WndProc(ref m);
    }
