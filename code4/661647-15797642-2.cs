    var def = new Pet { Name = string.Empty };
    var query = people
                .GroupJoin(pets,
                p1 => p1.FirstName,
                p2 => p2.Owner.FirstName,
                (p1, p2) => new { p1, p2 })
                .SelectMany(x => x.p2.DefaultIfEmpty(def),
                    (x, y) => new { FirstName = x.p1.FirstName, PetName = y.Name });
