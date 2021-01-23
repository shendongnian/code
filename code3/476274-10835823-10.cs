    var Cquery = (from Mstr in bsdb.BizOrgInsts
                  join Dat in bsdb.BizSurveyQ on Mstr.ID equals Dat.MASTERID
                  where Mstr.NIPAKEY == nipaKey & Mstr.FULCIRCORG == bOrg
                  orderby Mstr.STREETSUFX, Dat.ADDRESS, Mstr.NUMBER
                  select new BizSurveyCVM  { MasterId = Mstr.ID, Name = Mstr.OLDNAME, ...}
                 ).ToList();
    return View(Cquery);
