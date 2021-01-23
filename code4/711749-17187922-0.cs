    var endDate = Convert.ToDateTime(sqlReader["EndDay"])
    if (endDate < DateTime.Today)
    {
        member.Status = Status.Unpaid.ToString();
    }
