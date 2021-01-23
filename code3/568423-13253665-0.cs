    public class CompanyNameIgnoringSpaces : IEqualityComparer<LeadGridViewModel>
    {
        static Regex replacer = new Regex("[ -*&!]");
        public bool Equals(LeadGridViewModel x, LeadGridViewModel y)
        {
            return replacer.Replace(x.CompanyName, "")
                == replacer.Replace(y.CompanyName, "");
        }
        public int GetHashCode(LeadGridViewModel obj)
        {
            return replacer.Replace(obj.CompanyName, "").GetHashCode();
        }
    }
