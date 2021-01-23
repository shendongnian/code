      namespace autocomplete.Service
        {
            using System.Collections.Generic;
            using System.Linq;
        
            using System.ServiceModel;
            using System.ServiceModel.Activation;
            
            using System.Data;
        
            [ServiceContract(Namespace = "GetAutoCompleteService")]
            [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
            public class GetAutoComplete
            {
               
                [OperationContract]
                public List<Models> GetModels(string model)
                {
        
                   // Data access here to retrieve data for autocomplete box then convert to list
        
        // or however you get the data into list format
                    List<Models> List = dataJustPulled.ToList(); 
                    return List;
                }
            }
        }
