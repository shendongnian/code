    {
       if ( null != Owner )
       {
          FrmBlack frmBlackLocal = Owner as FrmBlack;
    
          if ( null != frmBlackLocal )
          {
             frmBlackLocal.NextAction = FrmBLack.NextActions.ShowForm2; //an enum
          }
       }
    
       Close();
    }
