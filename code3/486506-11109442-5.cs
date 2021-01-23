    class Data
    {
        public string Data1;
        public string Data2;
        public string Data3;
        public string Data4;
        public string Data5;
    }
------
    List<Data> myList = new List<Data>();
    //Split lines
    foreach(string s in lines)
    {
       string[] buffer = s.Split(' '); //split by space
       Data data = new Data();
       data.Data1 = string.Concat(buffer.Take(3).ToArray());
       data.Data2 = string.Concat(buffer.Skip(3).Take(6).ToArray());
       data.Data3 = string.Concat(buffer.Skip(9).Take(1).ToArray());
       data.Data4 = string.Concat(buffer.Skip(10).Take(1).ToArray());
       data.Data5 = string.Concat(buffer.Skip(11).Take().ToArray());
       myList.Add(data);
    }
