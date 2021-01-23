    var query = from p in db.POOL_SIE_SUPPORTs
                join c in db.ACCTs on p.ACCT_ID equals c.ACCT_ID
                where arr.Contains(p.ACCT_ID) && p.POOL_NO == 23 && p.FY_CD == "2013" && p.PD_NO == 12
                group p by new { p.ACCT_ID, p.ACCT_NAME } into s
                select new
                {
                    Account = s.Key.ACCT_ID,
                    AccountName = s.Key.ACCT_NAME, 
                    CTDActual = string.Format("{0:C}", s.Sum(y => y.CUR_AMT)),
                    CTDBudget = string.Format("{0:C}", s.Sum(y => y.CUR_BUD_AMT)),
                    YTDActual = string.Format("{0:C}", s.Sum(y => y.YTD_AMT)),
                    YTDBudget = string.Format("{0:C}", s.Sum(y => y.YTD_BUD_AMT))
               };
