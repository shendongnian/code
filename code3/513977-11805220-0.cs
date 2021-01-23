    public T Create<T>(T mi, MyVersion myv)
    {
        MyVersionEntity myve = _db.MyVersionEntity.Where(r => r.Id == myv.Id).First();
        MyIssueEntity mie = new MyIssueEntity();
        myve.MyIssueEntityAssoc.Add(mie);
        mie = _updateMyIssueEntity(mi, mie);
        mi.Id = mie.Id;
        return mi;
    }
