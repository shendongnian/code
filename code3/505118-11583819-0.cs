    private bool UpdateSchoolActivity()
    {
        ResetSchoolActivityErrors();
        SchoolActivity activityToUpdate = GetSchoolActivity();
    
        try
        {
            SessionApplication.SchoolActivities[schoolActivities.EditIndex] = activityToUpdate;
            ResetSchoolActivitiesEditIndex();
    
            BindSchoolActivities();
            ResetSchoolActivityFields();
            HideSchoolActivityFields();
        }
        catch (BrokenRuleException)
        {
            MapSchoolActivityErrors(activityToUpdate);
            SetSchoolActivitiesEditIndex(schoolActivities.EditIndex);
            BindSchoolActivities(); // That little guy? Don't worry about that little guy.
            return false;
        }
    
        return true;
    }
