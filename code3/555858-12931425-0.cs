    public IEnumerable<string> AvailableData {get; set;}
    
    [WebMethod] 
        public static void DisplayAvail()
        {
            this.AvailableData = GetRequiredData();
            return JSONConvert.SerializeObject(this.AvailableData);
        }
