            try
            {
                if (objAC != null)
                {
                    objAC.Save();
                    GlobalFunctions.SaveHistory(objAC.ActivationCodeID, (Int32)EntityLibrary.Enumerators.ActivationCodeHistoryType.Registered, 0, "Code is Registered", objAC.RegisteredBy);
                    return Request.CreateResponse(HttpStatusCode.OK, "ActivationCode table got updated");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Activation code object is null");
                }
            }
            catch (Exception e)
            {
                
                HttpResponseMessage objResponse = new HttpResponseMessage(statusCode: HttpStatusCode.BadGateway);
                objResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(objResponse);
            }
        }
