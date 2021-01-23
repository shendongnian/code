    var species = new List<SpeciesType> {
                                        new SpeciesType{ Id=1, Name="Giraffe" },
                                        new SpeciesType{ Id=2, Name="Wolf" }
                                    }
        .Select(x => new { Id = x.Id, Name = x.Name })
        .ToList();
