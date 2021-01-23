    db.Users.Join(db.Abjusters, outer => outer.id, inner => inner.userID, new { User = outer, Adjuster = inner })
        .GroupJoin(DBConcurrencyException.AdminAdjusterStatus, outer => outer.Adjuster.id, inner => inner.adjusterID, new { User = outer.User, Adjuster = outer.Adjuster, Admins = inner })
        .SelectMany(grp => grp.Admins.DefaultIfEmpty(), (grp, admin) => new { User = grp.User, Adjuster = grp.Adjuster, Admin = admin })
        .Where(item => item.User.userType == "adjuster" && item.Admin == null)
        .Select(item => new AdjusterProfileStatusItem { user = item.User, adjuster = item.Adjuster });
