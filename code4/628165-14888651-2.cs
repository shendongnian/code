    List<MyObject<string, string>> ListName = new List<MyObject<string, string>>();
    Dictionary<string, int> result = ListName.ToDictionary(key => key.String1, value => int.Parse(value.String2));
    public class MyObject<T, U>
    {
        public MyObject(T string1, U string2)
        {
            String1 = string1;
            String2 = string2;
        }
    
        public T String1 { get; set; }
        public U String2 { get; set; }
    }
