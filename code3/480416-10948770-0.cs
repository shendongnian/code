      var result = (from n in db.tbl_NAWs
                    join s in db.Status on n.Status equals s.StatusID
                    join a in db.tbl_Afdelings on n.Afdeling equals a.ID_Afdeling
                    join l in db.Locaties on n.Locatie equals l.LocatieID
                    select new 
                    {
                        ClassNR = n.ClassNr,
                        Status = s.Beschrijving,
                        Client = n.Aanspreekvorm,
                        Locatie = l.Naam,
                        Afdeling = a.Afdeling,
                        KamerNr = n.Kamernummer
                    }).ToList();
