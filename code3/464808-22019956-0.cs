    private string getOS()
    {
        string os = null;
        if (Request.UserAgent.IndexOf("Windows NT 5.1") > 0)
        {
            os ="Windows XP";
            return os;
        }
        else if (Request.UserAgent.IndexOf("Windows NT 6.0") > 0)
        {
            os= "Windows Vista";
            return os;
        }
        else if (Request.UserAgent.IndexOf("Windows NT 6.1") > 0)
        {
            os = "Windows 7";
            return os;
        }
        else if (Request.UserAgent.IndexOf("Intel Mac OS X") > 0)
        {
            //os = "Mac OS or older version of Windows";
            os = "Intel Mac OS X";
            return os;
        }
        else
        {
            os = "You are using older version of Windows or Mac OS";
            return os;
        }
        
    }
