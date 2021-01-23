    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace xmlCustomReformat
    {
        public class InsuredOrPrincipal 
    {
        XElement self;
        public InsuredOrPrincipal(XElement self) { this.self = self; }
        public GeneralPartyInfo GeneralPartyInfo { get { return _GeneralPartyInfo ?? (_GeneralPartyInfo = new GeneralPartyInfo(self.Element("GeneralPartyInfo"))); } }
        GeneralPartyInfo _GeneralPartyInfo;
        public InsuredOrPrincipalInfo InsuredOrPrincipalInfo 
        { get { return _InsuredOrPrincipalInfo ?? (_InsuredOrPrincipalInfo = new InsuredOrPrincipalInfo(self.Element("InsuredOrPrincipalInfo"))); } }
        InsuredOrPrincipalInfo _InsuredOrPrincipalInfo;
    }
    public class GeneralPartyInfo
    {
        XElement self;
        public GeneralPartyInfo(XElement self) { this.self = self; }
        public NameInfo NameInfo { get { return _NameInfo ?? (_NameInfo = new NameInfo(self.Element("NameInfo"))); } }
        NameInfo _NameInfo;
        public Addr Addr { get { return _Addr ?? (_Addr = new Addr(self.Element("Addr"))); } }
        Addr _Addr;
    }
    public class InsuredOrPrincipalInfo
    {
        XElement self;
        public InsuredOrPrincipalInfo(XElement self) { this.self = self; }
        public string InsuredOrPrincipalRoleCd
        {
            get { return (string)self.Element("InsuredOrPrincipalRoleCd"); }
        }
    }
    public class NameInfo
    {
        XElement self;
        public NameInfo(XElement self) { this.self = self; }
        public PersonName PersonName { get { return _PersonName ?? (_PersonName = new PersonName(self.Element("PersonName"))); } }
        PersonName _PersonName;
    }
    public class Addr
    {
        XElement self;
        public Addr(XElement self) { this.self = self; }
        public string Address1
        {
            get { return (string)self.Element("Addr1"); }
        }
        public string City
        {
            get { return (string)self.Element("City"); }
        }
        public string State
        {
            get { return (string)self.Element("StateProvCd"); }
        }
        public string Zip
        {
            get { return (string)self.Element("PostalCode"); }
        }
    }
    public class PersonName
    {
        XElement self;
        public PersonName(XElement self) { this.self = self; }
        public string Surname 
        { 
             get { return (string)self.Element("Surname"); } 
        }
        public string GivenName 
        {
            get { return (string)self.Element("GivenName"); }
        }
    }
