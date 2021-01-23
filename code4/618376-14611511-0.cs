    public class FindIt
    {
        // You need to let your derived class access the FindItFrm
        protected FindItFrm Frm;
        // Constructor needs to accept a FindItFrm
        public FindIt(FindItFrm frm)
        {
            Frm = frm;
        }
    }
    public class FindItFrm
    {
        private bool _amISet = false; 
        public bool AmISet
        {
            get { return _amISet; }
            set { _amISet = value; }
        }
    }
    public class MyHelper : FindIt
    {
        // Constructor
        public MyHelper()
            : base(new FindItFrm())
        {
            Frm.AmISet = true;
        }
    }
