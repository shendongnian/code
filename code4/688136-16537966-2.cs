    protected IEnumerable<string> SendState(Object ID_DIP,Object ID_SEQ,Object MODUL)
    {   
       ViewState["ssDIP"] = ID_DIP.AsString();
       ViewState["ssSEQ"] = ID_SEQ.AsString();
       ViewState["ssMOD"] = MODUL.ToString();
    
       yield return ID_DIP.AsString();
       yield return ID_SEQ.AsString();
       yield return MODUL.ToString();    
    }
