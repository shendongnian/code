    public class MyProp<TKey, TValue>
       where TValue : IEquatable<TKey>
    MyProp<TDictonary, TValor> prop = new MyProp<TDictonary, TValor>();
    var val = MyDictionary.FirstOrDefault(item => item.Equals(dictionary));
    prop.Key = val;
    prop.Value = val;
    return dic;
