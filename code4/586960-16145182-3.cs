	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Bm.Core;
	using JsonPrettyPrinterPlus;
	using ServiceStack.Common.Web;
	using ServiceStack.ServiceClient.Web;
	using ServiceStack.ServiceHost;
	using ServiceStack.ServiceModel.Serialization;
	using ServiceStack.ServiceModel.Support;
	using ServiceStack.WebHost.Endpoints;
	namespace Bm.Services.Plugins
	{
	    public class PrettyXmlFormatPlugin : IPlugin
	    {
		public const string XmlPrettyText = "application/prettyxml";
		public void Register(IAppHost appHost)
		{
		    appHost.ContentTypeFilters.Register(XmlPrettyText,
			 Serialize,
			 Deserialize);
		}
		public static void Serialize(IRequestContext requestContext, object dto, Stream outputStream)
		{
		    var xml = HttpResponseFilter.Instance.Serialize(ContentType.Xml, dto);
		    xml =  Common.PrettyXml(xml);
		    byte[] bytes = Encoding.UTF8.GetBytes(xml);
		    outputStream.Write(bytes, 0, bytes.Length);
		}
		public static object Deserialize(Type type, Stream fromStream)
		{
		    var obj = JsonDataContractDeserializer.Instance.DeserializeFromStream(type, fromStream);
		    return obj;
		}
	    }
	    public class PrettyXmlServiceClient : XmlServiceClient
	    {
		public PrettyXmlServiceClient()
		    : base()
		{
		}
		public PrettyXmlServiceClient(string baseUri)
		    : base(baseUri)
		{
		}
		public PrettyXmlServiceClient(string syncReplyBaseUri, string asyncOneWayBaseUri)
		    : base(syncReplyBaseUri, asyncOneWayBaseUri)
		{
		}
		public override string Format
		{
		    get
		    {
			return "prettyxml";
		    }
		}
	    }
	}
