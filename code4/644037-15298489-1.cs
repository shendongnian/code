        if (!String.IsNullOrEmpty(searchString))
        {
            var reviewMatches = _db.Reviews.Where(s => s.review.Contains(searchString));
            if (reviewMatches.Any())
            {
                return View(reviewMatches);      
            }
            else
            {
                var userMatches = _db.Reviews.Where(s => s.user.Contains(searchString));
                return View(userMatches);      
            }
