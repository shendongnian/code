    context.Owners
                .Select(o => new OwnerViewModel
                               		{
                                        OwnerID = o.OwnerID,
                                        HasPets = o.Pets.Any().
                                        ...
                                        ...
                                    });
