       public JsonResult GetProductsByDepList(string depID)
       {
           return GetProductByCatList(depID, null);
       }
       
       public JsonResult GetProductByCatList(string depID, string catID)
       {
           JsonResult jr = new JsonResult();
           var _product = null;
           if (!string.IsNullOrEmpty(catID))
           {
               _product = from a in   
                   DataContext.GetProductsByCat(Convert.ToInt32(depID),Convert.ToInt32(catID))
                   select new { ID = a.ID, ProName = a.Name };
           }
           else
           {
               _product = from a in DataContext.GetProductsByDep(Convert.ToInt32(depID))
                   select new { ID = a.ID, ProName = a.Name };
           } 
           jr.Data = _product.ToList();
           jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
           return jr;
       }
