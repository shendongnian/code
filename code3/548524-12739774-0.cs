     var data = (from con in dbData.tblPresenters
                            where con.PresenterID == ID
                            select new
                            {
                                Name = con.Name,
                               
                                Title = dbData.tblTitles.Where(x => x.TitleID == con.PresenterTitleID).ToList().Select(item => new tblTitle { Title = item.Title }).ToList()
                            }).ToList();
