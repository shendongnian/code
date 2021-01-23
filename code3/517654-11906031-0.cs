    public class VehicleMap : BaseUniqueNamedEntityMap<Vehicle>
    {
        public VehicleMap():
            base("vehicle_id", 40)
        {
            Not.LazyLoad();                
            //The main collection of items
            HasMany(x => x.mVehicleModels)                                        
                .OrderBy("date asc")
                .Cascade.AllDeleteOrphan()                    
                .LazyLoad()
                .KeyColumn("vehicle_id")
                .Inverse();
            //Always updated to the last added item
            References(x => x.mCurrentModel)
                .Column("current_vehicle_model_relation_id")
                .Not.Nullable()
                .Not.Insert();
        }
    }
