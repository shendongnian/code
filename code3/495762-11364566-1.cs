    public PartialViewResult getGrid1(string MainDDL1, string SubDDL1, string Search1)
    {
        DataSearchModel voModel = new DataSearchModel();
        voModel.dtResultSet1 = DLA.DataSearchContext.getResultSet1(MainDDL1, SubDDL1, Search1);
        return PartialView(MainDDL1, voModel);
    }
    public ViewResult DataSearch(string text)
    {
        DataSearchModel oModel = new DataSearchModel();
        oModel.alMainDDL = DLA.DataSearchContext.getMainDDL();
        return View(oModel);
    }
