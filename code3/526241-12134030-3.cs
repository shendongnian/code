    var profiles = from item in (from userprof in Ent.UserProfiles
      join userrating in Ent.UserRatings on userprofs.UserId equals userratings.UserId
      where userrating.DateAdded >= drm.Start
      select new{userrating.RatingValue, userrating.SomeThing, userprof.UserID, userprof.UserName}).AsEnumerable()
      group new{item.RatingValue, item.SomeThing} by new{item.UserID, item.UserName}
