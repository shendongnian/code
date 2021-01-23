            private void prosjektTimeGraf()
        {
            int estimerteTimer = 0;
            int registrerteTimer = 0;
            List<KeyValuePair<string, int>> estimerListe = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> registrertListe = new List<KeyValuePair<string, int>>();
            foreach (ProsjektTime p in Master.getDC().ProsjektTimes)
            {
                if (p.ProsjektID_FK == prosjekt.ProsjektID)
                {
                    estimerteTimer += p.AntallTimer;
                    estimerListe.Add(new KeyValuePair<string, int>(p.TimeTyper.Type, p.AntallTimer));
                }
            }
            foreach (ProsjektTimeBruker ptb in Master.getDC().ProsjektTimeBrukers)
            {
                if (ptb.ProsjektID_FK == prosjekt.ProsjektID)
                {
                    registrerteTimer += (int)ptb.AntallTimer;
                    registrertListe.Add(new KeyValuePair<string, int>(ptb.TimeTyper.Type, (int)ptb.AntallTimer));
                }
            }
            estimerListe.Insert(0, new KeyValuePair<string, int>("Totalt", estimerteTimer));
            registrertListe.Insert(0, new KeyValuePair<string, int>("Totalt", registrerteTimer));
            try
            {
                espTimer.DataContext = estimerListe;
                regpTimer.DataContext = registrertListe;
            }
            catch (InvalidOperationException e) { MessageBox.Show(e+""); }
        }
