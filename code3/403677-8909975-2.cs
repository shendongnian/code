    class BBB : AAA
    {
        public override void MyMethod(string s = "bbb")
        {
            base.MyMethod(s);
        }
        public override void MyMethod2()
        {
            this.MyMethod(); //added this keyword here
        }
    }
