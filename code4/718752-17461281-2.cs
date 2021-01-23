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
