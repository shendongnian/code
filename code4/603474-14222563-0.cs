    var classDict = new Dictionary<int, Class>();
    var studentDict = new Dictionary<int, Student>();
    // for ... loop starts here
    Class Class;
    if (!classDict.TryGetValue(myClassId, out Class))
    {
        Class Class = new Class() { ClassID = myClassId };
        context.Classes.Attach(Class);
        classDict.Add(myClassId, Class);
    }
    Student std;
    if (!studentDict.TryGetValue(myStdId, out std))
    {
        Student std = new Student() { Id = myStdId };
        context.Students.Attach(std);
        classDict.Add(myStdId, std);
    }
    Class.ClassStudents.Add(std);
    // loop ends here
    context.SaveChanges();
