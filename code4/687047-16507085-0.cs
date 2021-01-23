    public class MainVM
    {
        private static MainVM _instance = new MainVM();
        public static MainVM Instance { get { return _instance; } }
        public List<XX> MyList { get; set; }
        //other stuff here
    }
    //From within OtherVM:
    MainVM.Instance.MyList.Add(stuff);
