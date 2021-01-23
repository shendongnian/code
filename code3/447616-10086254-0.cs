    public JsonResult GetProductByCatList(string depID, string catID = null)
    {
      JsonResult jr = new JsonResult();
      if (String.IsNullOrEmpty(catID) 
      {
          var _product = from a in DataContext.GetProductsByDep(Convert.ToInt32(depID))  
          select new { ID = a.ID, ProName = a.Name };
          jr.Data = _product.ToList();      
      } else {
          var _product = from a in   
          DataContext.GetProductsByCat(Convert.ToInt32(depID),Convert.ToInt32(catID))
          select new { ID = a.ID, ProName = a.Name };
          jr.Data = _product.ToList();      
      }
      JsonResult jr = new JsonResult();
      return jr;
    }
