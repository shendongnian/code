    public bool GetSomeValueById(Guid innerId)
    {
        using(MyCompositeDisposable d = new MyCompositeDisposable(_uri, _id, innerId))
        {
            return d.C.GetSomeValue();
        }
    }
