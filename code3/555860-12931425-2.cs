    public IEnumerable<string> AvailableData {get; set;}
    
    [WebMethod] 
        public static void DisplayAvail()
        {
            this.AvailableData = GetRequiredData();
            this.AvailableData = JSONConvert.SerializeObject(this.AvailableData);
        }
