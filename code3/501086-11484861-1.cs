      public ActionResult repositoryTest() {
         ActionResult actionRes = default(ActionResult);
         using (ShkAdsEntities context = new ShkAdsEntities())
         using (WebOrderHdRepository webOrderHdRepository = new WebOrderHdRepository(context))
         using (WebOrderLnRepository webOrderLnRepository = new WebOrderLnRepository(context)) {
            var result = (from x in webOrderHdRepository.WebOrderHds
                          join u in webOrderLnRepository.WebOrderLns on x.OrderNo equals u.OrderNo
                          select new { x.OrderNo }).SingleOrDefault();
            actionRes = Content(result.OrderNo);
         }
         return actionRes;
      }
