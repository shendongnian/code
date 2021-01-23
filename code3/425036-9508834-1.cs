		public static class CouchbaseClientExtensions {
			public static bool BucketExists(this CouchbaseClient client, CouchbaseClientSection section = null) {
				
				section = section ?? (CouchbaseClientSection)ConfigurationManager.GetSection("couchbase");
				
				var webClient = new WebClient();            
				var bucketUri = section.Servers.Urls.ToUriCollection().First().AbsoluteUri;
				var response = webClient.DownloadString(bucketUri + "/buckets");               
				var jss = new JavaScriptSerializer();
				var jArray = jss.DeserializeObject(response) as object[];
				foreach (var item in jArray) {
					var jDict = item as Dictionary<string, object>;
					var bucket = jDict.Single(kv => kv.Key == "name").Value as string;
					if (bucket == section.Servers.Bucket) {
						return true;
					}                               
				}
				return false;
			}
		}
