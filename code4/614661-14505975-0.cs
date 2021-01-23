    abstract class BaseClass {
        public int ItemId { get; set; }
        public abstract string BaseUrl { get; }
        public string Url {
            get {
                return BaseUrl + ItemId;
            }
        }
    }
    
    class Type3 : BaseClass {
        public override string BaseUrl {
            get { return "/do/this/"; }
        }
    }
    
    class Type5 : BaseClass {
        public override string BaseUrl {
            get { return "/do/that/"; }
        }
    }
