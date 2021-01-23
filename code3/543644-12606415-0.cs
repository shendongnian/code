    string userId = Request["UserId"];
    string email = Request["Email"] ?? string.Empty;
    string lastFourdigits = Request["LastFourDigits"] ?? string.Empty;
    bool view = false;
    if (string.IsNullOrEmpty(userId))
    {
        view = true;
    }
    if (!view)
    {
        List<AAlexUsers.Models.SearchClass> searchClass = 
            AAlexUsers.Models.SearchClass.Users(userId,email,lastFourdigits);
        {
            ViewBag.searchClass = searchClass;
            ViewBag.lastFourdigits = lastFourdigits;
            ViewBag.userId = userId;
            ViewBag.email = email;
        }
    }
    return View();
