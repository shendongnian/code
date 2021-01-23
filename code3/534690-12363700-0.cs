    public class ProdCat
    {
        public int productId;
        public string productCategory;
    }
    public class ProductCatGroup
    {
        public string ProductCategory;
        public IList<int> ProdcutId;
    }
    public Form1()
    {
        List<ProdCat> ProdCatList = new List<ProdCat>();
        ProdCatList.Add(new ProdCat { productId = 1, productCategory = "A" });
        ProdCatList.Add(new ProdCat { productId = 2, productCategory = "B" });
        ProdCatList.Add(new ProdCat { productId = 3, productCategory = "A" });
        ProdCatList.Add(new ProdCat { productId = 4, productCategory = "C" });
        ProdCatList.Add(new ProdCat { productId = 5, productCategory = "A" });
        ProdCatList.Add(new ProdCat { productId = 6, productCategory = "B" });
        var productCatList = from pc in ProdCatList
            group pc by pc.productCategory into pcGroup
            select new ProductCatGroup { ProductCategory = pcGroup.Key, ProdcutId = pcGroup.Select(x => x.productId).ToList() }; 
    }
