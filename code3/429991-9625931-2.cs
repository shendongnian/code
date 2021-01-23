     [RestService("/codes/{Type}")]
     public class Codes {
          public string APIKey { get; set; }     
          public string Type { get; set; }
     }
     public class CodesResponse {
          public CodesResponse() {
               Results = new List<string>();
          }
          public List<string> Results { get; set; }
     }
     public class CodesService : RestServiceBase<Codes>
     {
          public override object OnGet(Codes request)
          {          
               APIClient c = VenueServiceHelper.CheckAndGetClient(request.APIKey, 
                  VenueServiceHelper.Methods.ListDestinations);
               var response = new CodesResponse();
               if (c == null) return response;
               if (request.Type == "counties") 
                    response.Results = General.GetListOfCounties();
               else if (request.Type == "destinations") 
                    response.Results = General.GetListOfDestinations();
               return response; 
         }
     }
