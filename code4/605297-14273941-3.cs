    protected bool MemberLogOut()
    {
        try {
            if (Session != null) {Session.Abandon();}
            //do any logging and additional cleanup here
            return true;
        } catch {
            return false;
        }
    }
            
