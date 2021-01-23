    static void Main(string[] args)
    {
        ClassB classB = new ClassB();
        classB.UpdateAndBind(classA => classA.IsBool1, (classA, value) => { classA.IsBool1 = !value; return classA; });
        classB.UpdateAndBind(classA => classA.IsBool2, (classA, value) => { classA.IsBool2 = !value; return classA; });
        classB.UpdateAndBind(classA => classA.IsBool3, (classA, value) => { classA.IsBool3 = !value; return classA; });
    }
