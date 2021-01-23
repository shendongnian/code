    string apikey = System.Configuration.ConfigurationManager.AppSettings["mailchimpapikey"];
    string listId = System.Configuration.ConfigurationManager.AppSettings["ListID"];
    
    var input = new listInterestGroupingsInput(apikey, listId);
    var lig = new listInterestGroupings(input);
    var success = lig.Execute(input);
