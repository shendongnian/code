    class Report
    {
        public Layout Layout { get; set; }
        public string EntityTypeFullName { get; set; }
        /// each Filter is a compare on one Property
        public ICollection<Filter> Filters { get; }
        public IList<Column> Columns { get; }
    }
    class Column
    {
        public string HeaderText { get; set; }
        /// e.g. Contract.User.Name
        public string AssociationPath { get; set; }
    }
    // in code
    var query = session.CreateCriteria(EntityTypeFullName);
    // recursive method which adds simple properties as Restrictions and calls itself
    // with query.CreateCriteria(referencePropertyName, Filters.Select(CropAssociationPath));
    AddFilter(query, report.Filters)
