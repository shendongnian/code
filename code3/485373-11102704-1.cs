        [HttpPost]
        public ActionResult statesByCountry(int IDCountry)
        {
            //your linq to filter the states by country for example
            var str = (from li in dbContext.countries
                       where li.Country_id == IDCountry
                       select new
                       {
                           id = li.State.IDState,
                           state = li.state
                       }).ToArray();
            return Json(str);
        }
