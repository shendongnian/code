    var userThemes = entities.Userthemes
                             .Where(ut => entities.Workplaces
                                                  .Where(w => w.WorkPlaceID == 2)
                                                  .Select(s => s.ThemeID)
                                                  .Contains(ut.ThemeID));
    foreach (UserTheme ut in userThemes)
    {
        if (ut.UserID.ToString() == "")
        {
            //Create
        }
        else
            ut.UserThemeAccessType = 2;
    }
