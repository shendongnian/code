    private int GetFriendsJoinedBeforeCount(DateTime joinDate)
    {
        List<DateTime> joinersDates = getJoinersDates();
        return joinersDates.Count(x => x < UserJoinDate);
    }
