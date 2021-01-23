           [HttpPost]
            public ActionResult EditTablo(Tablo tablo, int? RessamId, HttpPostedFileBase image)
            {
                if (ModelState.IsValid)
                {
                    if (tablo is TuvalBaski)
                    {
                        container.Urun.Attach((TuvalBaski)tablo);
                    }
                    else if (tablo is YagliBoya)
                    {
                        container.Urun.Attach((YagliBoya)tablo);
                    }
    
                    if (RessamId == null)
                    {
                        if(tablo.Ressam != null)
                        {
                            container.Ressam.Detach(tablo.Ressam);
                        }
    
                        tablo.Ressam = null;
                    }
                    else
                    {
                        if (tablo.Ressam != null)
                        {
                            container.Ressam.Detach(tablo.Ressam);
                        }
    
                        tablo.Ressam = (from table in container.Ressam
                                        where table.RessamId == RessamId
                                        select table).Single();
    
                        
                        container.Ressam.Attach(tablo.Ressam);
                    }
    
                    TryUpdateModel(tablo);
                    container.SaveChanges();
                }
    
                return View(tablo);
            }
