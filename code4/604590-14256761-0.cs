    public void AddOtherToMyEntity(MyEntity myEntity, OtherEntity otherEntity)
    {
        if(myService.Validate(otherEntity)
        {
          myEntity.Others.Add(otherEntity);
        }
        //else ...
    }
