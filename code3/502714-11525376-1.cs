    public class Vehicle
    {
        public int VehicleId {get;set}
        <snip>...</snip>
    
        [NotMapped]
        public virtual Make VehicleMake 
        {
            get { return Model.Make; }
            set { Model.Make = value; }
        }
    }
