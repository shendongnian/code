    public class Banner
    {
        public string LocationCodeString { get; set; }
        public int LocationCodeInt { get; set; }
        public string MediaUrl { get; set; }
    }
    
    public class CampaignWithChosenProposal
    {
        public List<Banner> Banners { get; set; }
        public string Code { get; set; }
        public string CustomerInstruction { get; set; }
        public string InfoLink { get; set; }
        public string LobbySubTitle { get; set; }
        public string LobbyTitle { get; set; }
        public string MoreText { get; set; }
        public int NumOfColumns { get; set; }
        public int NumOfRows { get; set; }
        public string OriginString { get; set; }
        public int OriginInt { get; set; }
        public List<List<>> Proposals { get; set; }
        public string RegulationsInfoLink { get; set; }
        public string ServiceType { get; set; }
        public string SubTitle { get; set; }
        public string SWDefault { get; set; }
        public string Title { get; set; }
    }
    
    public class User
    {
        public int CurrentLicenseNumber { get; set; }
        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RequestedLicenseNumber { get; set; }
        public string SubscriberPhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationStatus { get; set; }
    }
    
    public class RootObject
    {
        public string ValidationToken { get; set; }
        public string AppID { get; set; }
        public CampaignWithChosenProposal campaignWithChosenProposal { get; set; }
        public User User { get; set; }
        public string SalePersonID { get; set; }
    }
