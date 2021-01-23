    public override int SaveChanges()
        {
            var changeInfo = ChangeTracker.Entries()
                .Select(t => new {
                    Original = t.OriginalValues.PropertyNames.ToDictionary(pn => pn, pn => t.OriginalValues[pn]),
                    Current = t.CurrentValues.PropertyNames.ToDictionary(pn => pn, pn => t.CurrentValues[pn]),
                }).ToList();
            return base.SaveChanges();
        }
