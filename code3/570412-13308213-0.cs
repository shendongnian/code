        public void Save()
        {
            var inserts = _context.GetChangeSet().Inserts.ToList();
            _context.SubmitChanges();
            foreach(var entityAdded in inserts)
            {
                //raise event
            }
        }
