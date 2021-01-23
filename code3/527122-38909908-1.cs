     public static string Validate(ServiceAuthHeader soapHeader)
     {
            string error_msg = "Pass";
            if (soapHeader == null)
            {
                error_msg = "No soap header was specified.";
            }
            else if (soapHeader.Username == null || soapHeader.Username == "")
            {
               error_msg = "Username was not supplied for authentication in SoapHeader.";
            }
            else if (soapHeader.Password == null || soapHeader.Password == "")
            {
               error_msg = "Password was not supplied for authentication in SoapHeader.";
            }
            else if (soapHeader.Username != "test" || soapHeader.Password != "test")
            {
                 error_msg = "Please pass the proper username and password for this service.";
            }
          return error_msg;
     }
