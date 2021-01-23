        [Column]
        public int OrganizationId { get; set; } /*** Here is The Problem ***/
        private EntityRef<Organization> _organization;
        [Association(OtherKey = "OrganizationId", Storage = "_organization", ThisKey = "OrganizationId", IsForeignKey = true)]
        public Organization Organization
        {
            get
            {
                return this._organization.Entity;
            }
        }
