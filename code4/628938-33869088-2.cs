          public ActionResult GridViewPartialView()
    {
              return View();
    }
    
    
    [HttpPost]
            public ActionResult childGridViewPartialView(string recordId, string filtervalue, string flag)
            {
                if (flag == "GridRowChanged")
                {
                    IEnumerable result1;
                    griddetail result3;
                    if (recordId != null)
                    {
                        result1 = (new SlimHomePageData()).GetRecords(recordId, "");  //another result to be add later at the end of action method
                        result3 = (new SlimHomePageData()).GetOutlookGridDetail(recordId); //this was in my question
                    }
                    else
                    {
                        result1 = new List<SlimHomePageRecord>();   //another result to be add later at the end of action method
                        result3 = (new SlimHomePageData()).GetOutlookGridDetail(recordId); //this was in my question
                    }
    
                    List<object> finalResult = new List<object>();
                    finalResult.Add(result1);
                    finalResult.Add(result3);
                    return PartialView("OutlookGridDetail", finalResult);  
                }
                else
                {
                    return PartialView("childGridViewPartialView", (new SlimHomePageData()).GetRecords(null, null));
                }
            }
