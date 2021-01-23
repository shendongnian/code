    from forum in list
    let latest = forum.Topics.SelectMany(x => x.Messages).OrderByDescending(x => x.CreatedDate).First()
    select
        new ForumWith
            {
                ForumID = forum.ForumID,
                Name = forum.Name,
                topics = forum.Topics.Count,
                messages = forum.Topics.SelectMany(y => y.Messages).Count(),
                lastDate = latest.CreatedDate,
                lastUser = latest.CreatedBy
            };
