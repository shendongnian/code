    public void AddStudentTest()
    {
        var dbMock = new Mock3()
        StudentService target = new StudentService (new Mock1(),new Mock2(), dbMock, new Mock4(), new Mock5());
        string name  = "Sample Name";
        int actual = 0;
        string[] userNames = new string[] {"Sample User Name" };
        string[] roleName = new string[] {"Sample Role" };
        target.AddStudent (name, userNames, roleNames);                    
        Assert.IsNotNull(dbMock.Students.FirstOrDefault())
    }
