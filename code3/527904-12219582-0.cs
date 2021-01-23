    public virtual ActionResult getAjaxPGs(string SP = null)
            {
    
                if (SP != null)
                {
    
                    
                    var PGList = from x in db.month_mapping
                                 where x.PG_SUB_PROGRAM == SP 
                                 select x;
                                    
                    
    
                    
                    var PGRow = PGList.Select(x => new { x.PG }).Distinct().ToArray();
    
                    float[] PGContent = new float[12];
    
    
                    
    
                    Dictionary<string,float[]> MonthRow = new Dictionary<string, float[]>();
    
    
                    foreach (var item in PGRow)
                    {
                        
                            PGContent = new float[12];
                        
    
    
    
                        var MonthList = from x in db.month_Web
                                        where x.PG == item.PG
                                        group x by new { x.ACCOUNTING_PERIOD, x.PG, x.Amount } into pggroup
                                        select new { accounting_period = pggroup.Key.ACCOUNTING_PERIOD, amount = pggroup.Sum(x => x.Amount) };
    
                        foreach (var mon in MonthList)
                        {
                            int accounting_period = int.Parse(mon.accounting_period) - 1;
                            PGContent[accounting_period] = (float)mon.amount/1000000;
                        }
    
    
                        MonthRow[item.PG] = PGContent;
    
                        }
    
                   
    
                    return Json(MonthRow, JsonRequestBehavior.AllowGet);
    
                }
    
    
                return View();
            }
