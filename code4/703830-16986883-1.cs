     public JsonResult GetData(int? Id)
        {
            List<sp_data_R_Result> tableData;
            if (assetId != null)
                tableData = DBData.Where(x => x.Id== Id).ToList();
            else
                tableData = DBData.ToList();
            var res = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                        {
                            aaData = from d in tableData
                                     select new object[]
                                    {
                                      d.col1,
                                      d.col2,
                                      ...
                                     }
                        }
            };
            return res;
        }
