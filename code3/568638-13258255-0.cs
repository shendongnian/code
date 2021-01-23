    var result = JsonConvert.DeserializeObject<Result>(jsonString);
    class Result
    {
        public SuccessResult success { get; set; }
        public ErrorResult error { get; set; }
    }
    class SuccessResult
    {
        public string username { get; set; }
    }
    
    class ErrorResult
    {
        public int type { get; set; }
        public string address { get; set; }
        public string description { get; set; }
    }
