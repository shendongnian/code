    public Class course
    {
        public List<Test> tests = new List<Test>();
         //Place other course code here
    }
    public Class Test
    {
       public string Name;
       public Datetime Time;
       public int Number;
        Test(string name, Datetime time, int number)
        {
    Name = name;
    Time = time;
    Number = number;
        }
    }
