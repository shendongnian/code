    //for 2 queries
    var query = query1.Union(query2.Except(query2.Where(x=>query1.Any(y=>x.product_type==y.product_type&&x.product_size==y.product_size)))).OrderBy(x=>x.pkey);
    //for 1 query
    //the class/type to make the group key
    public class GroupKey
    {
            public int ProductType { get; set; }
            public int ProductSize { get; set; }
            public override bool Equals(object obj)
            {
                GroupKey gk = obj as GroupKey;
                return ProductType == gk.ProductType && ProductSize == gk.ProductSize;
            }
            public override int GetHashCode()
            {
                return ProductSize ^ ProductType;
            }
    }
    //-------
    var query = list.Where(x => x.region == 17 || x.region == null)
                    .GroupBy(x => new GroupKey{ProductType = x.product_type, ProductSize = x.product_size })
                    .SelectMany<IGrouping<GroupKey,Price>,Price,Price>(x => x.Where(k => x.Count(y => y.region == 17) == 0 || k.region == 17), (x,g) => g).OrderBy(x=>x.pkey);
