    public EmployeeMap() {
        Table("EmplTable");
        Id(x => x.Id).Column("Id");
        Map(x => x.FirstName).Column("FirstName");
        Map(x => x.LastName).Column("LastName");
        References(x => x.Login, "EmplId")
            .Fetch.Join(); 
    }
