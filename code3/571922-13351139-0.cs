    var result = (from q in query sele q).AsEnumerable()
                                           .Select( x => new Item()
                                           {
                                               ApprovedDate = x.ApprovedDate,
                                               CreatedDate = x.CreatedDate,
                                               DeclinedDate = x.DeclinedDate,
                                               Status = MyStatusFunction(x.CreatedDate,q.DeclinedDate)
                                           });
    public int MyStatusFunction(DateTime ApprovedDate , Datetime DeclinedDate)
    {
        if (ApprovedDate == null and DeclinedDate == null) return 0;
        else if(ApprovedDate != null and DeclinedDate == null) return 1;
        else if (DeclinedDate != null) return 3;
    }
