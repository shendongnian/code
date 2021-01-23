    public class CItems : List<Item>
            {
                [NonSerialized]
                public int ItemSum
                {
                    get
                    {
                        return this.Sum(x => (x is SimpleItem) ? x.Value : 0); 
                    }
                }
            }
