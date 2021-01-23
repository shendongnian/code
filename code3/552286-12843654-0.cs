    public class Details
    {
        public int Number { get; set; }
    
        public string MaskedNumber
        {
            get
            {
                var temp = Number.ToString();
                return new string('x', temp.Length - 4) + temp.Substring(temp.Length - 4);
            }
        }
    }
