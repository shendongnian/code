    public PartialViewResult getGrid1(string MainDDL1, string SubDDL1, string Search1)
    {
        DataSearchModel voModel = new DataSearchModel();
        voModel.dtResultSet = DLA.DataSearchContext.getResultSet(MainDDL1, SubDDL1, Search1);
        return PartialView(MainDDL1, voModel);
    }
    public PartialViewResult getGrid2(string MainDDL2, string SubDDL2, string Search2)
    {
        DataSearchModel voModel = new DataSearchModel();
        voModel.dtResultSet = DLA.DataSearchContext.getResultSet(MainDDL2, SubDDL2, Search2);
        return PartialView(MainDDL2, voModel);
    }
