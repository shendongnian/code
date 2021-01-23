    public class Details
    {
        public int Number { get; set; }
    
        public string MaskedNumber
        {
            get
            {
                var temp = Number.ToString();
                if (temp.Length <= 4)
                {
                    return temp;
                }
                return new string('x', temp.Length - 4) + temp.Substring(temp.Length - 4);
            }
        }
    }
