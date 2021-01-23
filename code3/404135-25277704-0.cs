    protected void Page_Load(object sender, EventArgs e)
    {
        sss s1, s2;
        s1 = new sss();
        s1.TotalMark = 10;
        s2 = new sss();
        s2.TotalMark = 20;
        sss.SchoolName = "St.Joseph's Hr.Sec.S"; //We can access through class and assign common to all
        s1.PrintData();
        s2.PrintData();
    }
    
    public class sss
    {
        public static string SchoolName { set; get; }
        public int TotalMark { set; get; }
        public string StudentName{set;get;}
        public void PrintData()
        {
            Console.WriteLine(TotalMark);
            Console.WriteLine(SchoolName);
            Console.WriteLine(StudentName);
        }
    }
