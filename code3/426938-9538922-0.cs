    public class BaseViewModel
    {
        int memID {get;set;}
        int caseUserID {get;set;}
        bool isMember {get;set;}
        bool isUser {get;set;}
        public void FillProperties()
        //These actions could also possibly be done on the fly in the properties
        {
            memID = (WebSessions.IsCUser) ? 0 : WebSessions.MemID;
            caseUserID = (WebSessions.IsCUser) ? WebSessions.CUserID : 0;
            isMember = !(WebSessions.IsCUser); 
            isUser = (WebSessions.IsCUser);
        }
    }
    public class Activity : BaseViewModel
    {
        //additional properties for Activity only
    }
    public class OpenTask : BaseViewModel
    {
        //additional properties for OpenTask only
    }
