        private void Something()
        {
                var query = GetStandardWhere(db.Kiosks);
                query = query.Where( //some new criteria);
                return query
                     .OrderByDescending(q => q.RedesignedAt)
                     .Take(1).Select(q => q.Type.DefinitionId).Contains(id)
                                   );
        }
        private IQueryable<KioskDesignation> GetStandardWhere(IQueryable<KioskDesignation> query)
        {
            return
                query.Where(
                    kiosk =>
                    db.KioskDesignations.Where(
                        q =>
                        q.Kiosk.KioskId == kiosk.KioskId &&
                        (!q.RedesignedAt.HasValue || q.RedesignedAt.Value <= DateTime.Now));
        }
