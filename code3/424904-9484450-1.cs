    // Original predicate without userId constraint
    Expression<Func<Photo, bool>> predicate = ph =>  
            ph.SearchMode == SearchMode.TagsOnly
         && ph.SearchText == tag
         && ph.PhotoSize == PhotoSize.Small
         && ph.Extras == (ExtrasOption.Owner_Name |  ExtrasOption.Date_Taken);
    
    if (!string.IsNullOrEmpty(username)) 
    {
        // Build the userId constraint into the predicate.
        var personId = (from people in context.Peoples
                        where  people.Username == username
                        select people.Id).First();
        // "And" combines the predicates
        // "Expand" removes the use of invocation expressions, which 
        // some LINQ providers have problems with.
        predicate = predicate.And(q => q.NsId == personId).Expand();
    }
    // Final result
    var photos = context.Photos.Where(predicate).Take(10);
