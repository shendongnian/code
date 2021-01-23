         using (var context = new EntityBazaCRM(Settings.sqlDataConnectionDetailsCRM)) {
                        if (currentUczestnik.SzkolenieUczestnicyID == 0) {
                            var nowy = new SzkolenieUczestnicy {
                                Konsultanci = context.Konsultancis.First(p => p.KonsultantNazwa == currentUczestnik.Konsultanci.KonsultantNazwa),
                                Szkolenie = context.Szkolenies.First(p => p.SzkolenieID == varSzkolenie.SzkolenieID),
                                SzkolenieUzytkownik = currentUczestnik.SzkolenieUzytkownik,
                                SzkolenieUzytkownikData = currentUczestnik.SzkolenieUzytkownikData,
                                UczestnikPotwierdzilUdzial = currentUczestnik.UczestnikPotwierdzilUdzial,
                                UczestnikPrzybyl = currentUczestnik.UczestnikPrzybyl
                            };
                            
                            context.SzkolenieUczestnicies.AddObject(nowy);
                            context.SaveChanges();
                            listaDoPodmiany.Add(nowy);
