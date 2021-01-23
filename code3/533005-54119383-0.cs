    using (var ctx = new MyContext())
          {
             ctx.Configuration.ProxyCreationEnabled = false;
             return ctx.Deferrals.AsNoTracking().Where(r => 
             r.DeferralID.Equals(deferralID)).FirstOrDefault();
          }
