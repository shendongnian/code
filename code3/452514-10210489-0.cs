    baseClass bc = new baseClass();
 
    Class1 class1 = new Class1();
    Class2 class2 = new Class2();
    long bcSize = 0;
    long class1Size = 0;
    long class2Size = 0;
    using (Stream s = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(s, bc);
        bcSize = s.Length; //223
    }
    using (Stream s = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(s, class1);
        class1Size = s.Length; //298
    }
    using (Stream s = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(s, class2);
        class2Size = s.Length; //264
    }
