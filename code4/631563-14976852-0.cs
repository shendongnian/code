    list.Select(
                x =>
                new ForumWith
                    {
                        ForumID = x.ForumID,
                        Name = x.Name,
                        topics = x.Topics.Count,
                        messages = x.Topics.SelectMany(y => y.Messages).Count(),
                        lastDate = x.Topics.SelectMany(y => y.Messages).OrderByDescending(y => y.CreatedDate).First().CreatedDate,
                        lastUser = x.Topics.SelectMany(y => y.Messages).OrderByDescending(y => y.CreatedDate).First().CreatedBy
                    });
