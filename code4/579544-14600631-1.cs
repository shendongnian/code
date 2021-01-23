    //
        // GET: /Services/Create
        **public ActionResult Create(Organisation_Names organisation_names)
        {
            DataSet ds = organisation_names.GetOrg_Names();
            ViewBag.OrganisationID = ds.Tables[0];
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (System.Data.DataRow dr in ViewBag.OrganisationID.Rows)
            {
                items.Add(new SelectListItem { Text = @dr["OrganisationName"].ToString(), Value = @dr["OrganisationID"].ToString() });
            }
            ViewBag.OrganisationID = items;
            return View();
     }
     //
        // POST: /Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        **public ActionResult Create(CreateServiceModel createservicemodel, Organisation_Names organisation_names, FormCollection selection)
        {
    DataSet ds = organisation_names.GetOrg_Names();
            if (ds == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganisationID = ds.Tables[0];
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (System.Data.DataRow dr in ViewBag.OrganisationID.Rows)
            {
                items.Add(new SelectListItem { Text = @dr["OrganisationName"].ToString(), Value = @dr["OrganisationID"] + 1.ToString() });
            }
            ViewBag.OrganisationID = items;**
    if (this.IsCaptchaVerify("Answer was incorrect. Please try again."))
            {
                try
                {
    int _records = createservicemodel.CreateService(createservicemodel.OrganisationID, createservicemodel.ServiceName, createservicemodel.ServiceDescription, createservicemodel.ServiceComments,   createservicemodel.ServiceIdentificationNumber, createservicemodel.CreatedBy, createservicemodel.NewServiceID);
                    if (_records > 0)
                    {
                        return RedirectToAction("Index", "Services");
                    }
                }
                catch
                //else
                {
                    ModelState.AddModelError("", "Cannot Create");
                }
            }
            {
                return View(createservicemodel);
            }
        }
