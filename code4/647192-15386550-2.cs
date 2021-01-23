    public void GetSomeDetailAboutAPerson(Person person)
    {
        return person.SomeSharedDetailFromBaseClass;
    }
    
    public void Something()
    {
        Teacher teacher = myService.GetTeacherById(3);
        var someDetailOrOther = this.GetSomeDetailAboutAPerson(teacher);
    }
