    [DataContract(Name = "Division", Namespace = "")]
    public class ApiTeamDivision : ApiDivision
    {
        [DataMember]
        public new ApiTeamEvent Event { get; set; }
       
        public new ApiDivisionSettings Settings { get; set; }
       
        public new List<ApiPrice> Prices { get; set; }
        
        public new List<ApiTeam> Teams { get; set; }
      
        public new List<ApiAsset> Assets { get; set; }
     
        public new List<ApiBracket> Brackets { get; set; }
    }
