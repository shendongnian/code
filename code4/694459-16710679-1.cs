    public class A
    {
        public static readonly Dictionnary<int, int[]> NumsArrays 
                  = new[]{{1, new[]{1,1,1}}, {2, new[]{2,2,2}}, {3, new[]{3,3,3}}};
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
    int id = (FooAttribute) Attribute.GetCustomAttribute(type, typeof (FooAttribute));
    int[] result = A.NumsArrays[id];//result is {3,3,3}
