    public static Func<Kiosk, bool> QueryCurrentKioskDesignation(DataContext db,
                                                                         Func<KioskDesignation, bool> predicate)
            {
                return k => db.KioskDesignations.Where(q => q.Kiosk.KioskId == k.KioskId &&
                                                                (!q.RedesignedAt.HasValue ||
                                                                 q.RedesignedAt.Value <= DateTime.Now))
                                       .OrderByDescending(q => q.RedesignedAt)
                                       .Take(1).Any(predicate);
            }
