    var paymentsRaw = (from p in mc.Paymnts
                   where p.POLICY == policy.ID ||
                         p.POLICY == policy.POL2
                   orderby p.PAYPD_ descending
                   group p by p.PAYPD_).ToList();
    var payments = from g in paymentsRaw 
                   select new 
                           {
                               payduedate = EntityFunctions.TruncateTime(g.FirstOrDefault().PAYDUE),
                               paypaiddate = EntityFunctions.TruncateTime(g.FirstOrDefault().PAYPD),
                               paymentamount = g.Sum(a=>a.AMOUNT),
                               paysuspense = g.FirstOrDefault().SUSP
                           };
