    ArrayList entityArrayList = new ArrayList();
    foreach(SPUser user in multipleUsers) // or just once for a single user
    {
        PickerEntity entity = new PickerEntity;
        entity.Key = user.LoginName;
        entity = peMyPeople.ValidateEntity(entity);
        entityArrayList.Add(entity);
    }
    peMyPeople.UpdateEntities(entityArrayList);
