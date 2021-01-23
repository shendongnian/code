    [XmlRoot("CampaignListXml")]
    public class CampaignList
    {
        [XmlElement]
        public Allcampaign Allcampaign;
    
        [XmlElement]
        public int TotalCount;
    }
    
    public class Allcampaign
    {
        [XmlElement("CompaignDTO", typeof(Campaign))]
        public Campaign[] CampaignArray;
    }
    
    public class Campaign
    {
        #region CTor
        public Campaign()
        {
        }
        #endregion
    
        #region Properties
    
        [XmlElement(ElementName = "Id_campaign")]
        public string ID_Campaign { get; set; }
        [XmlElement(ElementName = "Campaignname")]
        public string ElementName { get; set; }
        [XmlElement(ElementName = "Websiteurl")]
        public string WebsiteUrl { get; set; }
        [XmlElement(ElementName = "Privacypolicyurl")]
        public string PrivacyPolicyUrl { get; set; }
        [XmlElement(ElementName = "Termsurl")]
        public string TermsUrl { get; set; }
        [XmlElement(ElementName = "Pricepageurl")]
        public string PricepageUrl { get; set; }
        [XmlElement(ElementName = "Maxcredit")]
        public Int32 MaxCredit { get; set; }
        [XmlElement(ElementName = "Fk_id_currency")]
        public string FK_ID_Currency { get; set; }
        [XmlElement(ElementName = "Maxscans")]
        public short MaxScans { get; set; }
        [XmlElement(ElementName = "Startdate")]
        public DateTime Startdate { get; set; }
        [XmlElement(ElementName = "Enddate")]
        public DateTime Enddate { get; set; }
        [XmlElement(ElementName = "Starthour")]
        public short Starthour { get; set; }
        [XmlElement(ElementName = "Endhour")]
        public short Endhour { get; set; }
        [XmlElement(ElementName = "Pmam")]
        public string PMAM { get; set; }
        [XmlElement(ElementName = "Language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "Fk_id_merchantapp")]
        public string FK_ID_MerchantApp { get; set; }
        [XmlElement(ElementName = "Campaigntype")]
        public string CampaignType { get; set; }
        [XmlElement(ElementName = "Createtimestamp")]
        public DateTime CreateTimestamp { get; set; }
        [XmlElement(ElementName = "Lastupdate")]
        public DateTime LastUpdate { get; set; }
        [XmlElement(ElementName = "Lastupdateby")]
        public string LastUpdateBy { get; set; }
        [XmlElement(ElementName = "Status")]
        public short Status { get; set; }
    
        #endregion
    }
