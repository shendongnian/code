    protected bool MemberLogOut(HttpContext context)
    {
        try {
            if (context != null && context.Session != null) {
                context.Session.Abandon();
            }
            //do any logging and additional cleanup here
            return true;
        } catch (Exception ex) {
            //log here if necessary
            return false;
        }
    }     
