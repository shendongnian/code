    public void CheckingOutForUserReview()
    {
        string _data = "I want to pass in xml here";
        Assert.IsNotNull(_data);  <--------------- See the re-ordering
        var _Svc = new SubmissionsService();
        var _checkins = _Svc.CheckingOutForUserReview(_data);
    }
