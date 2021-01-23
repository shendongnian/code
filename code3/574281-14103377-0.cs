    <%@ Template Language="C#" TargetLanguage="C#" Description="http://stackoverflow.com/questions/13406669/c-sharp-class-generation-for-storing-values-in-the-session-state" %>
    <%@ Property Name="PropertyName" Default="SomeValue" Type="System.String" %>
    <%@ Property Name="SystemType" Default="string" Type="System.String" %>
    
    public static <%= SystemType %> <%= PropertyName %>
    {
        get
        {
            object obj = HttpContext.Current.Session["<%= PropertyName %>"];
            if (obj != null)
            {
                return (string)obj;
            }
    
            return null;
        }
    
        set
        {
            HttpContext.Current.Session["<%= PropertyName %>"] = value;
        }
    }
