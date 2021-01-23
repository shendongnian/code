      var datasource = testList.Select(s =>
                                     new
                                     {
                                         Count = s.Items.Count,
                                         Items = s.Items,
                                         Id = s.Id
                                     }).ToList();
                rptOuterRepeater.DataSource = datasource;
                rptOuterRepeater.DataBind();
