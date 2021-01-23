    public ActionResult TabInfo(int id, string tab)
        {
            try
            {
                var viewModel = _viewModelManager.GetViewModel(tab, id);
                ViewBag.Jobid = id;
                ViewBag.Tab = tab;
                return PartialView(string.Format("~/Views/{0}/Index.cshtml", tab), viewModel);
            }
            catch (Exception e)
            {
                return View("ErrorChildAction");
            }
        }
