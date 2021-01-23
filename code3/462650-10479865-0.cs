        [DataContract]
    public class Brands
    {
        [DataMember]
        public ObservableCollection<Brand> data;
    }
    [DataContract(Name = "data")]
    public class Brand
    {/* 
    public string BrandName; 
    public int BrandId; 
       */
        [DataMember]
        public string CompanyGUID;
        [DataMember]
        public int CompanyID; 
        [DataMember]
        public int CategoryID;
        [DataMember]
        public string Name;
        [DataMember]
        public string NameEn;
        [DataMember]
        public string Description;
        [DataMember]
        public string WebSite;
        [DataMember]
        public string Num;
        [DataMember]
        public string Num2;
        [DataMember]
        public string FaxNum;
        [DataMember]
        public string Email;
        [DataMember]
        public string Address;
        [DataMember]
        public string Twitter;
        [DataMember]
        public string Facebook;
        [DataMember]
        public string GooglePlus;
        [DataMember]
        public string App_iOS;
        [DataMember]
        public string App_Android;
        [DataMember]
        public string App_WinPhone;
        [DataMember]
        public string App_BlackBerry;
        [DataMember]
        public string Blog;
        [DataMember]
        public string Chat;
        [DataMember]
        public string Icon;
        [DataMember]
        public string SearchTags;
        [DataMember]
        public double Rating;
        [DataMember]
        public int Public;
        [DataMember]
        public int ToShow;
        [DataMember]
        public int Revision;
    } 
