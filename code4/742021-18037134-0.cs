    var refDate = DateTime.Today.AddDays(-8);
    
    int Count= P.Pets
                .Where(p => !p.Owner.Pets.Any(p1 => p1.IsOwned)
                            && p.CreatedDate >= refDate)
                .GroupBy(b => b.OwnerName).Count();
