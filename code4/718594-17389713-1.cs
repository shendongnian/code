      public void AlbumsDownloaded(object sender,   DownloadStringCompletedEventArgs e)
      {
     	    // Deserialize JSON string to dynamic object
            IDictionary<string, object> json = (IDictionary<string, object>)SimpleJson.DeserializeObject(e.Result);
            // Feed object
            IDictionary<string, object> feed = (IDictionary<string, object>)json["feed"];
    }
