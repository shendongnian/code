    static string messageVar = "C#";
    public static void Main(string[] args)
    {
        bool isSame = Test(messageVar); //true
        // what about in assignement?
        string messageVar2 = messageVar;
        isSame = Object.ReferenceEquals(messageVar2, messageVar);//also true
    }
    public static bool Test(string messageParam)
    {
        // logic
        bool isSame = Object.ReferenceEquals(messageParam, messageVar);
        return isSame;
    }
