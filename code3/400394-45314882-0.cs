	public class RouteDataContext : HttpContextBase {
		public override HttpRequestBase Request { get; }
		private RouteDataContext(Uri uri) {
			var url = uri.GetLeftPart(UriPartial.Path);
			var qs = uri.GetComponents(UriComponents.Query,UriFormat.UriEscaped);
			Request = new HttpRequestWrapper(new HttpRequest(null,url,qs));
		}
		public static RouteValueDictionary RouteValuesFromUri(Uri uri) {
			return RouteTable.Routes.GetRouteData(new RouteDataContext(uri)).Values;
		}
	}
