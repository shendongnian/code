                var uri = new Uri("http://whatever/");
                WebClient client = new WebClient();
                var collection = new Dictionary<string, string>();
                collection.Add("accountID", accountID );
                collection.Add("someKey", "someValue");
                var s = client.UploadValuesAsync(uri, collection);
