    [Inject]
        public IGradesRepository _Grades { get; set; }
    protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = _Grades;
        }
