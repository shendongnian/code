        using Bing;
        using System;
        using System.Data.Services.Client;
        using System.Linq;
        using System.Net;
        namespace StackOverflow.Samples.BingSearch
        {
            public class Finder
            {
                public void FindImageUrlsFor(string searchQuery)
                {
                    // Create a Bing container. 
                    string rootUri = "https://api.datamarket.azure.com/Bing/Search";
                    var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));
                    // Replace this value with your account key. 
                    var accountKey = "YourAccountKey";
                    // Configure bingContainer to use your credentials. 
                    bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
                    // Build the query. 
                    var imageQuery = bingContainer.Image(query, null, null, null, null, null, null);
                    imageQuery.BeginExecute(_onImageQueryComplete, imageQuery);
                }
                // Handle the query callback. 
                private void _onImageQueryComplete(IAsyncResult imageResults)
                {
                    // Get the original query from the imageResults.
                    DataServiceQuery<Bing.ImageResult> query =
                        imageResults.AsyncState as DataServiceQuery<Bing.ImageResult>;
                    var resultList = new List<string>();
                    foreach (var result in query.EndExecute(imageResults))
                    {
                        resultList.Add(result.MediaUrl);
                    }
                    FindImageCompleted(this, resultList);
                }
                public event FindImageUrlsForEventHandler FindImageUrlsForCompleted;
                public delegate void FindImageUrlsForEventHandler(object sender, List<string> result);
            }
        }
