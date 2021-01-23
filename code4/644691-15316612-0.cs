    public static List<ProductView> GetWithoutInvSoldOut()
    {
        using (var ctx = new DBSolutionEntities())
        {
            var data = ctx.Products.OrderBy(p => p.Name).ToList();
            return data.Select(x => CustomView(x, false)).ToList();
        }
    }
