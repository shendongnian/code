            mapping.Map(x => x.ThingID).Length(12);
            mapping.Map(x => x.Text).Length(5000).Not.Nullable();
            mapping.Map(x => x.CreatedDate).Not.Nullable();
            mapping.Map(x => x.Platform).Not.Nullable();
            mapping.Map(x => x.Type).Not.Nullable();
        }
        public class AppMappingOverride : IAutoMappingOverride<App>
        {
            public void Override(AutoMapping<App> mapping)
            {
                mapping.DynamicUpdate();
                mapping.DynamicInsert();
                mapping.HasManyToMany(x => x.Subscriptions).Inverse();
                mapping.HasManyToMany(x => x.Users).Inverse();
            }
        }
    
        public class SubscriptionMappingOverride : IAutoMappingOverride<Subscription>
        {
            public void Override(AutoMapping<Subscription> mapping)
            {
                mapping.DynamicInsert();
                mapping.DynamicUpdate();
                mapping.HasManyToMany(x => x.Apps);
            }
        }
