    namespace Engine.Api.Formatters
    {
    	using Newtonsoft.Json;
    	using Newtonsoft.Json.Linq;
    	using System;
    	using System.IO;
    	using System.Net;
    	using System.Net.Http;
    	using System.Net.Http.Formatting;
    	using System.Net.Http.Headers;
    	using System.Threading.Tasks;
    	using System.Web.Script.Serialization;
    	using System.Xml;
    	using System.Xml.Serialization;
    
    	public class ReducedJson
    	{
    		public dynamic WriteToStreamAsync(object value)
    		{
                        var json = new JavaScriptSerializer().Serialize(value);
        				var serializedJson = (JObject)JsonConvert.DeserializeObject(json);
        				foreach (var response in serializedJson["ProductData"]["Motor"]["QuoteResponses"])
        				{
        					response["NetCommResults"].Parent.Remove();
        					foreach (var netCommResult in response["BestPriceQuote"]["NetCommResults"])
        					{
        						netCommResult["Scores"].Parent.Remove();
        					}
        				}
        
              return serializedJson;
    		}
    }
