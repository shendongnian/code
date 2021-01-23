        // MySiteMaster : System.Web.UI.MasterPagepublic
     string Message
        {
        	get
        	{
        		return MessageContent.Text;
        	}
        	set
        	{
        		MessageContent.Text = value;
        	}
        }
    
        // MyPage : System.Web.UI.Page
        MySiteMaster masterPage = Master as MySiteMaster;
        masterPage.Message = "Message from content page";
