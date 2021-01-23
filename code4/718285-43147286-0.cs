    public class Money
    {
        [JsonIgnore]
        public decimal Money { get; set; }
    
        [JsonProperty("money")]
        public string MoneyAsString
        {
            get { return Money.ToString("0.00"); }
            set { Money = decimal.Parse(value); }
        }
    }
