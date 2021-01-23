        var modifiedComments = comments.Select(
            c => new
            {
                c.UserName,
                c.PostTitle,
                c.UserImage,
                c.Comment,
                c.UserID,
                XP = score.getLevel(c.XP)
            });
