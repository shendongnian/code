    [Authorize]
    public virtual ActionResult getAjaxSPs(string MP = null)
    {
        if (MP != null)
        {
            var SPList = from x in sp_index select x;
            var MPData = from y in mp_index
                            where y.MP_NAME == MP
                            select y;
            SPList = SPList.Where(x => x.MP_ID == MPData.FirstOrDefault().MP_ID);
            var SPRow = SPList.Select(x => new { x.SP_NAME, x.SP_ID }).Distinct().ToArray();  // <------- SPRow returns two variable SP_NAME and SP_ID (ex. Program1, 30) 
            float[] SPContent = new float[12];
            List<dynamic> result = new List<dynamic>();
            foreach (var item in SPRow)
            {
                var SPMonthList = from x in Full_Year_Numbers
                                    where x.PROJECT_NAME == item.SP_NAME
                                    group x by new { x.ACCOUNTING_PERIOD, x.PROJECT_NAME, x.AMOUNT } into spgroup
                                    select new { accounting_period = spgroup.Key.ACCOUNTING_PERIOD, amount = spgroup.Sum(x => x.AMOUNT) };
                foreach (var mulan in SPMonthList)
                {
                    int acounting_period = int.Parse(mulan.accounting_period) - 1;
                    SPContent[acounting_period] = (float)mulan.amount / 1000000;
                }
                result.Add(
                    new {
                        Name = item.SP_NAME,
                        Id = item.SP_ID,
                        Content = SPContent
                    });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        return View();
    }
