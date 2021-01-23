    public class Vehicle
    {
        public int VehicleId {get;set}
        <snip>...</snip>
    
        public int VehicleMakeId {get;set}
    
        public virtual Make VehicleMake {get;set;}
    }
    
    
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            this.HasKey(t => t.VehicleId);
            <snip>...</snip>
            this.HasRequired(t => t.VehicleMake)
            .WithMany(t => t.Vehicles)
            .HasForeignKey(t => t.VehicleMakeId);
        }
    }
