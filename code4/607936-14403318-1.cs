               public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            if (request.Properties.ContainsKey("UriTemplateMatchResults") && HttpContext.Current != null)
            {
                //get match for current request
                UriTemplateMatch match = (UriTemplateMatch)request.Properties["UriTemplateMatchResults"];
                Utils.ODataBasicUriParser uriParser = new Utils.ODataBasicUriParser(match.RequestUri.PathAndQuery);
                //verify if this is a SecondaryKey request
                if (uriParser.IsEntityQuery && uriParser.IsSecondaryKeyQuery)
                {               
                    //TODO this syntax is also used for entities with multiple pk's, test it
                    //get a new data context
                    //TODO see if this can be improved, avoid two datacontext for one request 
                    DataContext ctx = new DataContext();
                    Type outType;
                    //get entity type name from the service name 
                    string entityName = DataContext.GetEntityNameByServiceName(uriParser.EntityServiceName);
                    //get the pk for the entity
                    string id = ctx.GetEntityId(entityName, uriParser.EntityKey, uriParser.EntityId, out outType);
                    //verify if the pk has been found or cancel this to continue with standart request process
                    if (string.IsNullOrEmpty(id))
                    {
                        Trace.TraceWarning(string.Format("Key property not found for the the entity:{0}, with secondaryKeyName:{1} and secondaryKeyValue:{2}",
                            entityName, uriParser.EntityKey, uriParser.EntityId));
                        return System.Net.HttpStatusCode.NotFound;
                    }
                    //in odata syntax quotes are required for string values, nothing for numbers
                    string quote = outType.FullName == typeof(Int32).FullName || outType.FullName == typeof(Int64).FullName ? string.Empty : "'";
                    
                    //build the new standart resource uri with the primary key
                    var newUri = new Uri(string.Format("{0}/{1}({2}{3}{2})", match.BaseUri.ToString(), uriParser.EntityServiceName, quote, id));
                    //create a new match to replace in the current request, with the new Uri
                    UriTemplateMatch newMatch = NewMatch(match, newUri); 
                    //set request values
                    request.Properties["UriTemplateMatchResults"] = newMatch;
                    request.Headers.To = newUri;
                    request.Properties.Via = newUri;
                }
            }
            return null;
        }
       
        UriTemplateMatch NewMatch(UriTemplateMatch match, Uri newUri)
        {
            UriTemplateMatch newMatch = new UriTemplateMatch();
            newMatch.RequestUri = newUri;
            newMatch.Data = match.Data;
            newMatch.BaseUri = match.BaseUri;
            return newMatch;
        }
   
