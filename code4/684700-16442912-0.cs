    [HttpPost]
            public JsonResult GetData(GridSettings gridSettings)
            {
                var data = Enumerable.Range(0, 1000).Select(s => DateTime.Now.AddHours(s * 4)).ToList();
                    
                var totalRecords = data.Count();
    
                if (!string.IsNullOrWhiteSpace(gridSettings.SortColumn))
                {
                    data = (gridSettings.SortOrder == "asc" ?
                        data.OrderBy(x=>x) :
                        data.OrderByDescending(x=>x)).ToList();
                }
                data = data.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize).ToList();
    
                var id = (gridSettings.PageIndex - 1) * gridSettings.PageSize;
    
                var jsonData = new
                {
                    total = totalRecords / gridSettings.PageSize + 1,
                    page = gridSettings.PageIndex,
                    records = totalRecords,
                    rows = data.Select(d=>new
                        {
                            id = ++id,
                            Date = d.ToShortDateString()
                        })
                };
                return Json(jsonData);
            }
