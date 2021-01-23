    [NonAction]
    public static IEnumerable<UserProfile> SearchCMSAdmins(string s)
    {
        string[] ids = s.Split(',');
        foreach (string idAsString in ids)
        {
            int id = Convert.ToInt32(idAsString);
            var entity = Entities.UserProfiles.Where(item => item.UserId == id);
            yield return entity;
        }
    }
