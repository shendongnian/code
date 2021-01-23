                foreach (SzkolenieUczestnicy uczestnik in listaUczestnikow.Objects) {
                    using (var context = new EntityBazaCRM(Settings.sqlDataConnectionDetailsCRM)) {
                        if (uczestnik.SzkolenieUczestnicyID == 0) { // add new object
                            var konsultant = uczestnik.Konsultanci; 
                            uczestnik.Konsultanci = null; // null attached object and reuse it's ID later on for SAVE purposes
                            uczestnik.KonsultantNazwa = konsultant.KonsultantNazwa;
                            uczestnik.Szkolenie = null; // null attached object and reuse it's ID later on for SAVE purposes
                            uczestnik.SzkolenieID = szkolenie.SzkolenieID;                       
                            context.SzkolenieUczestnicies.AddObject(uczestnik);
                            context.SaveChanges();
                            context.Detach(uczestnik); // detatch to prevent Context problems
                            uczestnik.Szkolenie = szkolenie;// reassign for use in ObjectListView
                            uczestnik.Konsultanci = konsultant; // reassign for use in ObjectListView
                        } else { // modify exisinng object 
                            context.SzkolenieUczestnicies.Attach(uczestnik);
                          
                           //context.ObjectStateManager.ChangeObjectState(uczestnik, EntityState.Modified);
                            context.SaveChanges();
                        }
                    }
                }
