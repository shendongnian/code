            public class Entity
            {
              public MyEnum Property { get; set; }
            }
            var returnedFromDB = 1;
            var entity = new Entity();
            entity.Property = (MyEnum)returnedFromDB ;
