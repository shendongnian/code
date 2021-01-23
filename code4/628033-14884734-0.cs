     void Application_Error(object sender, EventArgs e)
     {
          Exception ex = Server.GetLastError();
          LogException(ex);
          HttpContext.Current.Response.Redirect("~/Error.aspx");
     }
     //Somewhere Else
     void LogException(Exception ex)
     {
          WriteExceptionToEndOfTextFile(ex);
          SendEmail();
     }
