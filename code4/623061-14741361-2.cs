    [HttpPost]
    public ActionResult ICD10ConditionSearch(string ICD10SearchTerms)
    {
        String[] terms = ICD10SearchTerms.Split(' ');
        CommonCodeEntities dataContextCommonCodes = new CommonCodeEntities(ConnectionString);
        IQueryable<ICD10Codes> codes = dataContextCommonCodes.ICD10Codes
           .Where(e => terms.Any(k => e.ICD10CodeTitle.Contains(k)).AsQueryable();
         
        return Json(codes);
    }
