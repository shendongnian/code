    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using JsonPrettyPrinterPlus;
    using ServiceStack.Common.Web;
    using ServiceStack.ServiceClient.Web;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceModel.Serialization;
    using ServiceStack.ServiceModel.Support;
    using ServiceStack.WebHost.Endpoints;
    
    namespace Bm.Services.Plugins
    {
        public class PrettyJsonFormatPlugin : IPlugin
        {
            public const string JsonPrettyText = "application/prettyjson";
            public void Register(IAppHost appHost)
            {
                appHost.ContentTypeFilters.Register(JsonPrettyText,
                     Serialize,
                     Deserialize);
                
            }
    
            public static void Serialize(IRequestContext requestContext, object dto, Stream outputStream)
            {
      			var json = HttpResponseFilter.Instance.Serialize(ContentType.Json, dto);
                
                json = json.PrettyPrintJson();
                byte[] bytes = Encoding.UTF8.GetBytes(json);
    
                outputStream.Write(bytes, 0, bytes.Length);
            }
    
            public static object Deserialize(Type type, Stream fromStream)
            {
                var obj = JsonDataContractDeserializer.Instance.DeserializeFromStream(type, fromStream);
                return obj;
            }
    
        }
    
        public class PrettyJsonServiceClient : JsonServiceClient
        {
            public PrettyJsonServiceClient() : base()
            {
            }
    
            public PrettyJsonServiceClient(string baseUri) : base(baseUri)
            {			
            }
    
            public PrettyJsonServiceClient(string syncReplyBaseUri, string asyncOneWayBaseUri) : base(syncReplyBaseUri, asyncOneWayBaseUri)
            {
            }
    
            public override string Format
            {
                get
                {
                    return "prettyjson";
                }
            }
        }
    }
