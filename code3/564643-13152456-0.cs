    Protected void SetSessionTime( userType) {
        if ( UserType ="admin")
        {
          Session.Timeout = 180;
        }
        else
        {
          Session.Timeout = 20;
        } }
