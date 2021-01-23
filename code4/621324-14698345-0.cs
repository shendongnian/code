      // Create the object and get the feed 
       RC.Gmail.GmailAtomFeed gmailFeed = new RC.Gmail.GmailAtomFeed("username", "password"); 
       gmailFeed.GetFeed(); 
     
       // Access the feeds XmlDocument 
       XmlDocument myXml = gmailFeed.FeedXml 
     
       // Access the raw feed as a string 
       string feedString = gmailFeed.RawFeed 
     
       // Access the feed through the object 
       string feedTitle = gmailFeed.Title; 
       string feedTagline = gmailFeed.Message; 
       DateTime feedModified = gmailFeed.Modified; 
     
       //Get the entries 
       for(int i = 0; i &lt; gmailFeed.FeedEntries.Count; i++) { 
          entryAuthorName = gmailFeed.FeedEntries[i].FromName; 
          entryAuthorEmail = gmailFeed.FeedEntries[i].FromEmail; 
          entryTitle = gmailFeed.FeedEntries[i].Subject; 
          entrySummary = gmailFeed.FeedEntries[i].Summary; 
          entryIssuedDate = gmailFeed.FeedEntries[i].Received; 
          entryId = gmailFeed.FeedEntries[i].Id; 
       }
