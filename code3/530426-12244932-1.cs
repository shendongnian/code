    public static int Count(this IQueryable<Mail> mails, MailCountParameter p)
    {
        return mails.Count(m =>
            m.ProjectName == p.ProjectName &&
            p.Languages.Contains(m.MailLang) &&
            m.EnteredBetween(p.StartTime, p.EndTime) &&
            m.Priority == p.Priority);
    }
    public static bool EnteredBetween(this Mail mail, DateTime startTime, DateTime endTime)
    {
        return mail.DateEntered >= startTime && mail.DateEntered <= endTime;
    }
