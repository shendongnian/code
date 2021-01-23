    public class CompanyNameIgnoringSpaces : IEqualityComparer<Company>
    {
        public bool Equals(Company x, Company y)
        {
            return x.Name.Replace(" ", "") == y.Name.Replace(" ", "");
        }
        public int GetHashCode(Company obj)
        {
            return obj.Name.Replace(" ", "").GetHashCode();
        }
    }
