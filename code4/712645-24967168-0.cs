    public void InsertAll(IEnumerable<MyClass> list)
        {
            DataContext.MyClasses.InsertAllOnSubmit<MyClass>(list);
            DataContext.SubmitChanges();
        }
