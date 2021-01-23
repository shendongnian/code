        [HttpPost]
        public ActionResult ICD10ConditionSearch(string ICD10SearchTerms)
        {
            String[] terms = ICD10SearchTerms.Split(' ');
            CommonCodeEntities dataContextCommonCodes = new CommonCodeEntities(ConnectionString);
            var codes = dataContextCommonCodes.ICD10Codes
               .Where(e => terms.Any(k => e.ICD10CodeTitle.Contains(k)).ToList();
         
           return Json(codes);
        }
