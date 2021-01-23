    public List<ItemCustom2> GetBrandListByCat(int id)
        {
            var OBJ = (from a in db.Items
                       join b in db.Brands on a.BrandId equals b.Id into abc1
                       where (a.ItemCategoryId == id)
                       from b in abc1.DefaultIfEmpty()
                       select new
                       {
                           ItemCategoryId = a.ItemCategoryId,
                           Brand_Name = b.Name,
                           Brand_Id = b.Id,
                           Brand_Pic = b.Pic,
                       }).Distinct();
            List<ItemCustom2> ob = new List<ItemCustom2>();
            foreach (var item in OBJ)
            {
                ItemCustom2 abc = new ItemCustom2();
                abc.CategoryId = item.ItemCategoryId;
                abc.BrandId = item.Brand_Id;
                abc.BrandName = item.Brand_Name;
                abc.BrandPic = item.Brand_Pic;
                ob.Add(abc);
            }
            return ob;
        }
 
