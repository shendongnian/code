        [WebMethod(EnableSession = true)]
        public static string Save(string details)
        {
              ServiceResponse serviceResponse =new ServiceResponse();
              /// rest of the usual code of yours   
              ///
              if (a< b)
              {
                 //rest of the code
                  serviceResponse.IsSuccess= true;
                  serviceResponse.Message = String.Join(",",data.ToArray());
              }
              else
              {
                 //rest of the code
                 serviceResponse.IsSuccess = false;
              }
            return new JavaScriptSerializer().Serialize(serviceResponse);
        }
   
