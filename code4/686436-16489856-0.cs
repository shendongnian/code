    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    
    namespace FeedZilla
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.feedzilla.com/v1/categories/26/articles/search.json?q=syria");
    
    			using (var responseStream = request.GetResponse().GetResponseStream())
    			{
    				using (var reader = new StreamReader(responseStream))
    				{
    					var fzResult = Newtonsoft.Json.JsonConvert.DeserializeObject<FZResult>(reader.ReadToEnd());
    
    					fzResult.Articles.ForEach(a => Console.WriteLine("{0} {1}", a.Title, a.Url));
    				}
    			}
    		}
    
    		[DataContract]
    		public class FZResult
    		{
    			[DataMember(Name = "articles")]
    			public List<Article> Articles { get; set; }
    		}
    
    		public class Article
    		{
    			[DataMember(Name = "title")]
    			public string Title { get; set; }
    
    			[DataMember(Name = "url")]
    			public string Url { get; set; }
    		}
    	}
    }
