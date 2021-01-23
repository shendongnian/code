    public Actionresult GetCustomerInf()
    {
     var cm=new CustomerInfo();
     cm.Name="Some Name";
     cm.Age=23;
     return Json(cm,JsonRequestBehaviour.AllowGet);
    }
