        //use this internally
        private List<IVehicle> _vehicles;
		public ReadOnlyCollection<IVehicle> Vehicles
		{
			get { return _vehicles.AsReadOnly(); }
		}
