    public IQueryable<Course> GetCourses(){
        var dlo = new DataLoadOptions();
        dlo.LoadWith<StudentCourses>(d => d.Course);
        this.LoadOptions = dlo;
        return this.GetTable<StudentCourses>().Select(d=>d.Course);
    }
