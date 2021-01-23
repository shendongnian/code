    public void AddInformationToSomeObjects(IEnumerable<SomeObject> someObjects)
    {
        someObjects =
            from obj in someObjects
            join dbObj in db.Table
            on obj.ObjectID equals dbObj.ObjectID
            select new SomeObject
            {
                ObjectID = obj.ObjectID,
                StringA = obj.StringA,
                StringB = dbObj.StringB,
                StringC = dbObj.StringC
            }
    }
