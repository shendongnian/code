    public class EntityDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        ...
    }
    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public EntityDto MyEntity(int entityId)
    {
        AccessObject accessObject = new AccessObject("MyConnectionString");
        MyEntity theEntity = accessObject.GetByID(entityID);
        return new EntityDto()
        {
            ID = theEntity.ID,
            Description = theEntity.Description,
            ...
        };
    }
