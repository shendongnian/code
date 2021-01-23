     public class IntermediaryMap :  ClassMap<Intermediary>
     {
        public IntermediaryMap()
        {
            Id(x => x.Pkey);
            Map(x => x.Name);
            HasManyToMany(x => x.SubBrokers).Table("Intermediary2SubBroker")
                .ParentKeyColumn("IntermediaryFKey")
                .ChildKeyColumn("SubBrokerFKey")
                .AsSet();
        }
     }
