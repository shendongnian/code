    public class ObjectAMap : ClassMapping<ObjectA> {
        public ObjectAMap () {
            Table("ObjectABase");
            Id<Guid>(x => x.Id, m => { m.Column("Id"); });
            Property(x => x.PropertyA, map => { map.Column("PropertyA"); });
            Property(x => x.PropertyB, map => { map.Column("PropertyB"); });
            Join("ObjectA",
                 m => {
                     m.Table("ObjectAExtended");
                     m.Key(x => { x.Column("Id"); });
                     m.Property<string>(x => x.PropertyC, map => { map.Column("PropertyC"); });
                     m.Property<string>(x => x.PropertyD, map => { map.Column("PropertyD"); });
                 });
					
            });	
        }
    }
