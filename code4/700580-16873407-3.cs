    public ActionResult Cities(int regionId)
    {
      IList<SelectListItem> cities;
      using (DatingEntities context = new DatingEntities())
      {
        cities = (from c in context.cities
                  where c.RegionID == regionId
                  select new SelectListItem()
                  {
                    Value = c.CityId,
                    Text = c.Name
                  }).ToList();
      };
      return PartialView("_SelectList", cities);
    }
