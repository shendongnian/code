    var list=new List<SelectListItem>(); 
    list.AddRange(cities.Select(o => new SelectListItem
                {
                    Text = o.Name,
                    Value = o.CityId.ToString()
                }));
            }
    return Json(list);
