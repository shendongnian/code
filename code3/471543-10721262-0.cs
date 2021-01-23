    function dostuff()
    {
      // code here
    }
    
    C# code in code behind
     protected void callmethod()
        {
            StringBuilder oSB = new StringBuilder();
             Type cstype = this.GetType();
    
    
            try
            {
                oSB.Append("<script language=javaScript>");
                oSB.Append("dostuff();");
                oSB.Append("</script>");
                Page.ClientScript.RegisterClientScriptBlock(cstype, Guid.NewGuid().ToString(), oSB.ToString(), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oSB = null;
            }
        }
