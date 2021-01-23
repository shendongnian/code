    Expression<Func<Photo, bool>> predicate = ph =>  
            ph.SearchMode == SearchMode.TagsOnly
         && ph.SearchText == tag
         && ph.PhotoSize == PhotoSize.Small
         && ph.Extras == (ExtrasOption.Owner_Name |  ExtrasOption.Date_Taken);
    
    if (!string.IsNullOrEmpty(username))
    {
        var personId = (from people in context.Peoples
                        where  people.Username == username
                        select people.Id).First();
        predicate = predicate.And(q => q.NsId == personId).Expand();
    }
    var photos = context.Photos.Where(predicate).Take(10);
