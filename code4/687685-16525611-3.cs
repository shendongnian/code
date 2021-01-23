        [WebMethod(EnableSession = true)]
        public static string Save(string details)
        {
              string message =string.Empty;
              /// rest of the usual code of yours   
              ///
              if (a< b)
              {
                 //rest of the code
                 message = "Insertion Successful";
              }
              else
              {
                 //rest of the code
                 message = "Error Occured";
              }
        }
     
    and in your client side inside the ajax `success`, simple do this:
        success: function (result) {
                       alert(result.d);
        }
