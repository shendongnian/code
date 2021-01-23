    var itemsWithComments = db.Items.Select(o => new
    {
        Item = o,
        Comments = o.Comments.Where(c => c.UserId == userId)
    });
