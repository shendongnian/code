    public class A
    {
        public static readonly Dictionnary<int, int[]> NumsArrays = ...;
        public const int Num1 = 1;
        public const int Num2 = 2;
        public const int Num3 = 3;
    }
    public class FooAttribute : Attribute
    {
        public int NumsId { get; set; }
        FooAttribute()
        {
        }
    }
    [Foo(NumsID = A.Num3)]
    public string Box { get; set; }
    //Evaluation:
    int id = (FooAttribute) Attribute.GetCustomAttribute(type, typeof (DeveloperAttribute));
    int[] result = A.NumsArrays[id];
