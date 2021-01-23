    public MyCustomInfo GetThatInfo()
    {
        var thatObject=new MyCustomInfo();
        try
        {
           //Do something 
           thatObject.OperationStatus.IsSuccess=true;
        }
        catch(Exception ex)
        {
          thatObject.OperationStatus.ErrorMessage=ex.Message;
          thatObject.OperationStatus.InnerException =(ex.InnerException!=null)?ex.InnerException:"";
        }
        return thatObject;
    }
