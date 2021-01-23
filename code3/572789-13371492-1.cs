    public class Ref<T> where T : struct
    {
        public T Value {get; set;}
    }
    List<Ref<int>> intRefList = new List<Ref<int>>();
    var myIntRef = new Ref<int> { Value = 1 };
    intRefList.Add(myIntRef);
    Console.WriteLine(myIntRef.Value);//1
    Console.WriteLine(intRefList[0].Value);//1
    myIntRef.Value = 2;
    Console.WriteLine(intRefList[0].Value);//2
