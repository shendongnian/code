    BsonClassMap.RegisterClassMap<Role>(m =>
        {
            m.MapIdProperty(r => r.Id).SetRepresentation(BsonType.ObjectId);
            m.MapProperty(r => r.Users).SetSerializationOptions(
                    new ArraySerializationOptions(new
                            RepresentationSerializationOptions(BsonType.ObjectId)));
         });
