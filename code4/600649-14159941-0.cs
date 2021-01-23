      public ActionResult FamilyPArameterValueDdl(string id)
            {
                var tmpParameter = DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters.Where(e => e.Code == id).FirstOrDefault();
                return PartialView("_FamilyPArameterValueDdl",tmpParameter);
            }
        public ActionResult FamilyPArameterValueTextBox(string id)
        {
            var tmpParameter = DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters.Where(e => e.Code == id).FirstOrDefault();
            return PartialView("_FamilyPArameterValueTextBox", tmpParameter);
        }
        public ActionResult _EditMaterial_EditParameters(string id)
        {
            var tmpParameter = DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters.Where(e => e.Code == id).FirstOrDefault();
            string FamilyParameterValueView;
            // get the parameter that will edit 
            if(tmpParameter.PossibleValues.Any())
            {
                  FamilyParameterValueView = Url.Action("FamilyPArameterValueDdl");
            }
            else
            {
                 FamilyParameterValueView = Url.Action("FamilyPArameterValueTextBox");
            }
            
           
            return Json(new { familyParameterValueView = FamilyParameterValueView });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult _EditMaterial_UpdateParameters(string id,FamilyParameter familyParameter)
        {
            var tmpFamilyParameterList = new List<FamilyParameter>();
            tmpFamilyParameterList = DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters.ToList();
            var tmpFamilyParameter = tmpFamilyParameterList.Find(e => e.Code == id);
            var tmpIndexOf = tmpFamilyParameterList.IndexOf(tmpFamilyParameter);
            tmpFamilyParameter.Value = familyParameter.Value;
            tmpFamilyParameterList.Remove(tmpFamilyParameter);
            tmpFamilyParameterList.Insert(tmpIndexOf, tmpFamilyParameter);
            DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters = tmpFamilyParameterList.AsQueryable();
            return Json(DetailHvmModel.HvmModel.CurrentArticle.Family.Parameters);
        }
