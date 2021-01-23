    var query = _db.Comments.Join(
        _db.Topics,
        c => c.TopicId,
        t => t.Id,
        (comment, topic) =>
           new
           {
               Comment = comment,
               Topic = topic
           });
