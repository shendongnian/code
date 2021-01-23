    public class D
    {
        public string UserNameB { get; set; }
        public string PasswordB { get; set; }
        public string UserNameC { get; set; }
        public string PassWordC { get; set; }
        public D(B b, C c)
        {
            UserNameB = b.UserName;
            PasswordB = b.PassWord;
            UserNameC = c.UserName;
            PassWordC = c.PassWord;
        }
    }
