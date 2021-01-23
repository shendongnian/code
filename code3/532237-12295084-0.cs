    var newTags = tagarray.Except(dataContext.Tags.Select(t => t.Tag));
    // var duplicateTags = tagarray.Intersect(dataContext.Tags.Select(t => t.Tag));
    foreach (var newTag in newTags)
    {
       db.AddToTags(newTag);
    } 
    db.SubmitChanges(ConflictMode.ContinueOnConflict);
           
