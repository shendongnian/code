    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    /// <summary>
    /// 
    /// </summary>
   
    public class PersPolicy
    {
        XElement self;
        public PersPolicy(XElement self) { this.self = self; }
        public CreditScoreInfo CreditScoreInfo { get { return _CreditScoreInfo ?? (_CreditScoreInfo = new CreditScoreInfo(self.Element("CreditScoreInfo"))); } }
        CreditScoreInfo _CreditScoreInfo;
        public string PolicyNumber
        {
            get { return (string)self.Element("PolicyNumber"); }
            set { self.Element("PolicyNumber").SetValue(value); }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CreditScoreInfo
    {
        XElement self;
        public CreditScoreInfo(XElement self) { this.self = self; }
        public string CreditScore
        {
            get { return (string)self.Element("CreditScore"); }
            set { self.Element("CreditScore").SetValue(value); }
        }
        public string CreditScoreDt
        {
            get { return (string)self.Element("CreditScoreDt"); }
            set { self.Element("CreditScoreDt").SetValue(value); }
        }
    }
