    protected string SendState(Object ID_DIP,Object ID_SEQ,Object MODUL)
    {
         var returnValue = new List<string>();
              try
              {
                    ViewState["ssDIP"] = ID_DIP.ToString();
                    ViewState["ssSEQ"] = ID_SEQ.ToString();
                    ViewState["ssMOD"] = MODUL.ToString();
    
    
                    returnValue.add(ID_DIP.AsString());
                    returnValue.add(ID_DIP.AsString());
                    returnValue.add(MODUL.ToString());
                    
              }
              catch (Exception)
              {
                    returnValue = null;
              }
         return returnValue;
    }
