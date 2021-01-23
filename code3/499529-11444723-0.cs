      var comments = db.Comments.ToList();
            string concatComments = string.Empty;
            foreach (var item in comments)
            {
                concatComments = concatComments + item.Title;
            }
            ViewData["Concat"] = concatComments.ToString();
