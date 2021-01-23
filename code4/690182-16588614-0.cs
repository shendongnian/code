    public static List<MyClass> myClassList = new List<MyClass>();
    public static List<MyClass> Assign (List<MyQuiz> assign, int i)
    {
        myClassList.Add(new MyClass(assign[i].ID, assign[i].MyVar));
        return myClassList;
    }
