    public class InsuredOrPrincipal 
    {
        XElement self;
        public InsuredOrPrincipal(XElement self) { this.self = self; }
        public GeneralPartyInfo GeneralPartyInfo { get { return _GeneralPartyInfo ?? (_GeneralPartyInfo = new GeneralPartyInfo(self.GetElement("GeneralPartyInfo"))); } }
        GeneralPartyInfo _GeneralPartyInfo;
        public InsuredOrPrincipalInfo InsuredOrPrincipalInfo 
        { get { return _InsuredOrPrincipalInfo ?? (_InsuredOrPrincipalInfo = new InsuredOrPrincipalInfo(self.GetElement("InsuredOrPrincipalInfo"))); } }
        InsuredOrPrincipalInfo _InsuredOrPrincipalInfo;
    }
    public class GeneralPartyInfo
    {
        XElement self;
        public GeneralPartyInfo(XElement self) { this.self = self; }
    
        public NameInfo NameInfo { get { return _NameInfo ?? (_NameInfo = new NameInfo(self.GetElement("NameInfo"))); } }
        NameInfo _NameInfo;
    
    }
    public class InsuredOrPrincipalInfo
    {
        XElement self;
        public InsuredOrPrincipalInfo(XElement self) { this.self = self; }
    
        public string InsuredOrPrincipalRoleCd
        {
            get { return Get("InsuredOrPrincipalRoleCd", string.Empty); }
        }
    }
    
    public class NameInfo
    {
        XElement self;
        public NameInfo(XElement self) { this.self = self; }
    
        public PersonName PersonName { get { return _PersonName ?? (_PersonName = new PersonName(self.GetElement("PersonName"))); } }
        PersonName _PersonName;
    }
    
    public class PersonName
    {
        XElement self;
        public NameInfo(XElement self) { this.self = self; }
    
        public string Surname 
        { 
             get { return self.Get("Surname", string.Empty); } }
             set { self.Set("Surname", value, false); }
        }
    }
