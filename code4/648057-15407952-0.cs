    var entity = _db.AlleBenutzer.FirstOrDefault(p => p.Id == id);
        if (entity != null)
        {
            var abteilungObjekt = _db.AlleAbteilungen.FirstOrDefault(p => p.Abteilungsname == abteilung);
            if (abteilungObjekt != null)
            {
                var etageObjekt = _db.AlleEtagen.Include(p => p.Abteilung).FirstOrDefault(p => p.Etagenname == etage);
                if (etageObjekt != null)
                {
                    entity.Abteilung = abteilungObjekt;
                    entity.Etage = etageObjekt;
                    _db.Entry(entity.Abteilung).State = EntityState.Modified;
                    _db.Entry(entity.Etage).State = EntityState.Modified;
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }
