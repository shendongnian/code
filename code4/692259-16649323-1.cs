    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> _dic=new Dictionary<int,string>();
            _dic.Add(5,"xyz");
            _dic.Add(2,"abc");
            _dic.Add(1,"pqr");
            _dic.Add(4,"test");
            _dic.Add(3,"pvf");
            var _ordered=_dic.OrderBy(d => d.Key).ToDictionary(d=> d.Key,d=>d.Value);
            _dic=new Dictionary<int,string>(_ordered);
        }
    }
