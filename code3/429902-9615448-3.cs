    Dictionary<string, IEnumerable<Node>> result = new Dictionary<string, IEnumerable<Node>>();
    foreach(var subscriber in subscribers)
    {
        var nodesToSend = from n in news.AsParallel()
            where n.GetProperties("cities").Value.Split(',')
                    .Any(c => subscriber.CityNodeIds.Contains(Convert.ToInt32(c)) &&
                n.GetProperties("categories").Value.Split(',')
                    .Any(c => subscriber.CategoryNodeIds.Contains(Convert.ToInt32(c))
            select n;
        if (nodesToSend.Count > 0)
            result.Add(subscriber.Email, nodesToSend);
    }
    if (result.Count > 0)
    {
        foreach (var res in result)
        {
            // Finally, create/merge the markup for the newsletter and send it as an email.
        } 
    }
