    public class EntityMap : CsvClassMap<Entity>
        {
            public override void CreateMap()
            {
                Map(m => m.Field1).Name("<Field1>");
                Map(m => m.Field2).Name("<Field2>");
            }
        }
