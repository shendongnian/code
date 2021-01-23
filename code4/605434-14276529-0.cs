    public class test
    {
        public int i;
        public string str;
        public Socket s;
        public DateTime dt;
    }
    test t1 = new test { i = 1, str = "string1", s = soc1, dt = DateTime.Today };
    test t2 = new test { i = 2, str = "string2", s = soc2, dt = DateTime.Today };
    test t3 = new test { i = 3, str = "string3", s = soc3, dt = DateTime.Today };
    ArrayList a = new ArrayList();
    a.Add(t1);
    a.Add(t2);
    a.Add(t3);
