    class AdvancedFTS : 
             DatabaseExtensions.IStoredProcedure<AdvancedFTSDTO> {
        public string SearchText { get; set; }
        public int MinRank { get; set; }
        public bool IncludeTitle { get; set; }
        public bool IncludeDescription { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string FilterTags { get; set; }
    }
