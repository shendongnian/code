            PlusService plus = new PlusService();
            plus.Key = "YOURAPIKEYGOESHERE";
            ActivitiesResource ar = new ActivitiesResource(plus);
            ActivitiesResource.Collection collection = new ActivitiesResource.Collection();
            //107... is the poster's id
            ActivitiesResource.ListRequest list = ar.List("107200121064812799857", collection); 
            ActivityFeed feed = list.Fetch();
            //You'll obviously want to use a _much_ better way to get
            // the activity id, but you aren't normally searching for a
            // specific URL like this.
            string activityKey = "";
            foreach (var a in feed.Items)
                if (a.Url == "https://plus.google.com/107200121064812799857/posts/GkyGQPLi6KD")
                {
                    activityKey = a.Id;
                    break;
                }
            ActivitiesResource.GetRequest get = ar.Get(activityKey);
            Activity act = get.Fetch();
            Console.WriteLine("Title: "+act.Title);
            Console.WriteLine("URL:"+act.Url);
            Console.WriteLine("Published:"+act.Published);
            Console.WriteLine("By:"+act.Actor.DisplayName);
            Console.WriteLine("Annotation:"+act.Annotation);
            Console.WriteLine("Content:"+act.Object.Content);
            Console.WriteLine("Type:"+act.Object.ObjectType);
            Console.WriteLine("# of +1s:"+act.Object.Plusoners.TotalItems);
            Console.WriteLine("# of reshares:"+act.Object.Resharers.TotalItems);
            Console.ReadLine();
