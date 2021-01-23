    container.Register(Component
             .For<IDBViewerModel>()
             .ImplementedBy<DBViewerModel>()
             .LifeStyle.PerWebRequest
             .DependsOn(Dependency.OnComponent("dataDB", "myservice.dataDB")));
    container.Register(Component
             .For<IMembershipModel>()
             .ImplementedBy<MembershipModel>()
             .LifeStyle.PerWebRequest
             .DependsOn(Dependency.OnComponent("uaxDB", "myservice.uaxDB")));
    container.Register(
           Component.For<IMongoConnection>()
               .ImplementedBy<MongoConnection>()
               .Named("myservice.dataDB")
               .DependsOn(Property.ForKey("DBlocation").Eq(USERmongoURL),
                    Property.ForKey("DB").Eq(USERmongoCollection))
               .LifeStyle.PerWebRequest,
           Component.For<IMongoConnection>()
               .ImplementedBy<MongoConnection>()
               .Named("myservice.uaxDB")
               .DependsOn(Property.ForKey("DBlocation").Eq(UAXmongoURL),
                    Property.ForKey("DB").Eq(UAXmongoCollection))
               .LifeStyle.PerWebRequest
       );
