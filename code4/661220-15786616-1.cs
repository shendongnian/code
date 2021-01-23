    public ActionResult _Menu()
        {
            IEnumerable<DynaPortalMVC.Models.Page> model = new List<DynaPortalMVC.Models.Page>
            {
                new DynaPortalMVC.Models.Page { Name = "Page1" },
                new DynaPortalMVC.Models.Page { Name = "Page2" },
                new DynaPortalMVC.Models.Page { Name = "Page3" },
                new DynaPortalMVC.Models.Page { Name = "Page4" },
            };
            return PartialView("_Menu", model);
        }
