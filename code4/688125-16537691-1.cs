    protected MyReturnObject SendState(Object ID_DIP, Object ID_SEQ, Object MODUL)
    {
        try
        {
            ViewState["ssDIP"] = ID_DIP.ToString();
            ViewState["ssSEQ"] = ID_SEQ.ToString();
            ViewState["ssMOD"] = MODUL.ToString();
    
            MyReturnObject obj = new MyReturnObject();
            obj.ID_DIP = ID_DIP.ToString();
            obj.ID_SEQ = ID_SEQ.ToString();
            obj.MODUL = MODUL.ToString();
            return obj;
        }
        catch (Exception)
        {
            return null;
        }
    }
