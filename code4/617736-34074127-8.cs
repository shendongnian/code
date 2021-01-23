        /// <summary>
        /// Defines the physical location of the department
        /// </summary>
        public const string F_PHYSICALLOCATIONS = "PhysicalLocations";
		[ForeignKey("PhysicalLocations")]
        public string DepartmentId { get; set; }
		private Location _physicalLocations;
		public virtual Location PhysicalLocations { get { return _physicalLocations; } set { _physicalLocations = value; } }
