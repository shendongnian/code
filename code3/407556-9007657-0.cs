    public class ItemViewMap : IAutoMappingOverride<ItemView>
    {
        public void Override(AutoMapping<ItemView> mapping)
        {
            mapping.Id(x => x.Column).GeneratedBy.Assigned();
        }
    }
