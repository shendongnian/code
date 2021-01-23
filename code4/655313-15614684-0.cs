        private void DataPortal_Fetch()
        {
            using (var ctx = Csla.Data.ObjectContextManager<Datenbank.TestDBEntities>.GetManager(EntitiesDatabase.Name))
                ReadData(ctx.ObjectContext.Farben);
        }
        private void ReadData(IEnumerable<Datenbank.Farbe> data)
        {
            // Partial Method BeforeReadData
            RaiseListChangedEvents = false;
            foreach (var item in data)
                this.Add(Farbe.Get(item));
            RaiseListChangedEvents = true;
        }
