    /// <summary>
            /// Creates concatenation object that will not be mapped in the database but will be in the
            /// Object Relational Mapping (ORM) of the EF model.
            /// </summary>
            [NotMapped]
            public string TagAndLocation { get { return Tag + " (" + Location.Name + ")"; } } 
