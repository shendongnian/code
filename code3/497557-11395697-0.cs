    public class ContentEqualityComparer : IEqualityComparer<Content>
    {
    
        public bool Equals(Content c1, Content c2)
        {
            return (c1.ContentID == c2.ContentID);
        }
    
    
        public int GetHashCode(Content c)
        {
            return c.ContentID.GetHashCode();
        }
    
    }
