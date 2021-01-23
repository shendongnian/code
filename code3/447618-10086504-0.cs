       public JsonResult GetProductsByDepList(string depID)
       {
           GetProductByCatList(depID, null);
       }
    
       public JsonResult GetProductByCatList(string depID, string catID)
       {
           JsonResult jr = new JsonResult();
           if (!string.IsNullOrEmpty(catID))
           {
               var _product = from a in   
               DataContext.GetProductsByCat(Convert.ToInt32(depID),Convert.ToInt32(catID))
           }
           else
           {
              var _product = from a in DataContext.GetProductsByDep(Convert.ToInt32(depID))
           } 
           select new { ID = a.ID, ProName = a.Name };
           jr.Data = _product.ToList();
           jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
           return jr;
       }
