    // you should have a list of primitive types to use in SQL IN keyword
    var ids = articleByTags.Tags.Select(t => t.Id).ToList();
    var query = (from article in context.Articles
                  // do you want same article again? NO! so remove the current article
                 where article.Id != articleByTags.Id
                 // this line would create a IN statement to SQL
                 // if you don't want to load common tags, you can merge this line
                 // by the next it, and just create a COUNT()
                 let commonTags = article.Tags.Where(tag => ids.Contains(tag.Id))
                 let commonCount = commonTags.Count()
                 // there as any?
                 where commonCount > 0
                 // ascending! not descending! you want most common 
                 orderby commonCount ascending
                 // create your projection
                 select new {
                     Id = article.Id,
                     Title = article.Title,
                     Tags = article.Tags,
                     Commons = commonTags,
                     CommonCount = commonCount
                     // or any property you want...
                })
                // how many you want to take? for example 5
                .Take(5)
                .ToList();
