    public class TestList {
        private List<TestModel> wow_;
        public List<TestModel> wow {
           get {
              if (wow_ == null) wow_ = new List<TestModel>();
              return wow_;
           }
           set {wow_ = value;}
        }
     }
