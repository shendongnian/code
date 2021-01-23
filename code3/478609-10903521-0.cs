    public void FillWsvcStructs<ClassType>(DataSet ds) where ClassType : IElemRequest, new()
    {
        IFoo.Request = ds.DataTable[0].Request;
        IFoo.Modulebq = string.Empty;
        IFoo.Clasific = string.Empty;
        IFoo.Asignadoa = ds.DataTable[0].Referer;
        IFoo.Solicita = "Jean Paul Goitier";
        // Go with sub-Elems (Also "Interfaceated")
        foreach (DataSet.DataTableRow ar in ds.DataTable[1])
        {
            if ((int) ar.StatusOT != (int)Props.StatusOT.NotOT)
            {
                ///From HERE!
                IElemRequest req = new ClassType();
                ///To HERE!
                req.Id = string.Empty;
                req.Type = string.Empty;
                req.Num = string.Empty;
                req.Message = string.Empty;
                req.Trkorr = ar[1];
                TRequest.Add(req);
            }
        }
    }
