     public void Create(Exchanger ex, long clientId)
        {
            if (_context != null)
            {
                ex.ClientId = clientId;
                ex.LastTimeUpdated = DateTime.UtcNow;
               **var ps = ex.PaymentSystems.Select(x=>x.Id);
                var ps2 = _context.PaymentSystems.Where(x => ps.Any(y => y == x.Id)).ToList();
                ex.PaymentSystems.Clear();
                foreach (var pp in ps2)
                {
                    ex.PaymentSystems.Add(pp);
                }**
                
                _context.Exchangers.Add(ex);
                _context.SaveChanges();
            }
        }
