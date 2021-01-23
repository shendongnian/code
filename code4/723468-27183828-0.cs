                content.Url = "http://192.168.10.217/
                SI518/%28W%284%29%29/Soap/SOS.asmx";
                content.CookieContainer = new System.Net.CookieContainer();
                SOSReference.LoginResult lresult = content.Login("admin", "admin");
                content.Timeout = 100000;
                SOSReference.SO641010Content PrintSoOrder = content.SO641010GetSchema();
                content.SO641010Clear();
                List<SOSReference.Command> commandPL = new List<SOSReference.Command>
                {  
                new SOSReference.Value{ Value ="CM" ,
                    LinkedCommand = PrintSoOrder.Parameters.OrderType},     
                new SOSReference.Value{ Value ="000861" ,
                    LinkedCommand = PrintSoOrder.Parameters.OrderNumber},  
                PrintSoOrder.ReportResults.PdfContent            
                };
