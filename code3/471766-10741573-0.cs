        [HttpPost]
        public ActionResult RptPkgsRecd(PackageVals model)
        {
            ViewBag.CurrentPage = "reports";
            try
            {
                if (ModelState.IsValid)
                {
                    PackageVals pv = new PackageVals();
                    pv.dps = regpacksRepository.GetSubmitted(model.datePass.DateIn, model.datePass.DateOut).ToList();
                    return View(pv);
                }
                else
                {
                    PackageVals pv = null;
                    return View(pv);
                }
            }
            catch(SystemException ex)
            {
                var error = ex.ToString();
                this.ModelState.AddModelError(error, ex);
                PackageVals pv = null;
                return View(pv);
            }
        }
