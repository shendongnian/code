    public ActionResult IsChanged(string fieldName, int parentID)
    {
        using (MyEntities _db = new MyEntities())
        {
            bool isChanged = false; 
                
                string[] aName = fieldName.Split('.');
                string strTableName = aName[0];
                string strFieldName = aName[1];
                
                string strQuery = String.Format("select distinct {0} from {1} where parentID = {2}", strFieldName, strTableName, parentID);
                isChanged = _db.ExecuteStoreQuery<dynamic>(strQuery).Count() > 1;
                    
                return Json(isChanged, JsonRequestBehavior.AllowGet);
        }
    }
