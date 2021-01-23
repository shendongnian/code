    [TestMethod]
    public void TestMethod1() {
       var campaigns = new List<Campaign>(){
           new Campaign {ProfileId = "Jan"},
           new Campaign {ProfileId = "Jan"},
           new Campaign {ProfileId = "Feb"},
           new Campaign {ProfileId = "Mar"},
           new Campaign {ProfileId = "Jan"},
           new Campaign {ProfileId = "Jan"},
       };
       var notJanCampaigns = campaigns.Where(c => c.ProfileId != "Jan");
       Assert.AreEqual(2, notJanCampaigns.Count());
            
    }
    class Campaign {
        public string ProfileId { get; set; }
    } 
