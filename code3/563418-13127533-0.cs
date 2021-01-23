    [WebMethod]
    public static Result CheckIfPacked(string orderNumber) {
       var mesEntity = new MESEntities();
       var packh = from packhead in mesEntity.Packing_Transaction_Headers
                   where packhead.Order_No_ == orderNumber
                   select packhead.Completed_by_Packer;
       if (packh.First() == 0)
       {
          return new Result { Success = true, Message = string.Format("You have not finished packing order {0}, are you sure you want to navigate away from this page?", orderNumber) };
       }
       else
       {
          return null;
       }
    } 
