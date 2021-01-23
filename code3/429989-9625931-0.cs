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
          public override object OnGet(ListAllResponse request)
          {          
               APIClient c = VenueServiceHelper.CheckAndGetClient(request.APIKey, 
                  VenueServiceHelper.Methods.ListDestinations);
               if (request.Type == "counties") 
               {
                    return new CodesResponse {
                         Results = General.GetListOfCounties()
                    }
               }
               else if (request.Type == "destinations") 
               {
                    return new CodesResponse {
                         Results = General.GetListOfDestinations()
                    }
               }
               return new CodesResponse(); 
         }
     }
