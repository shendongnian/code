    for (int i = 1; i < 21; i++)
          {
            wsCall.Service1SoapClient CallWebService = new wsCall.Service1SoapClient();
                
            lstBox.Items.Add(CallWebService.getNumber(i));
          }
