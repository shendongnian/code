    public class MyEntityMappingOverride : IAutoMappingOverride<MyEntity>
    {
         public void Override(AutoMapping<MyEntity> mapping)
         {
             mapping.Map(x => x.MyProperty).Default("100");
         }
    }
