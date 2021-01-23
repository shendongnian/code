    Teacher teacher = new Teacher("This is valid", new Student());
    Student st = new Student();
    try
    {
        teacher = new Teacher("", st);
    }
    catch (... etc ...)
