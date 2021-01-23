    var selectedPracticeforEncounter = (from selectedPractice in selectedPracticeInfo
                                             where selectedPractice.PracticeId == Convert.ToInt32(ddlPractice.SelectedValue)
     select new PropPractice
    {
    PracticeId = selectedPractice.PracticeId,
    PracticeName = selectedPractice.PracticeName,
    TimeZoneDisplayName = selectedPractice.TimeZoneDisplayName
    }).SingleOrDefault();
