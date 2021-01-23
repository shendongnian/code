    return (_entities.Users.AsEnumerable().Select(profile => new ProfileUserListItemDto
                    {
                        Email = profile.Email,
                        FirstName = profile.FirstName,
                        Id = profile.Id,
                        LastName = profile.LastName,
                        Role = DtoEntityLookups.EntityRoleToDtoRole(profile.Role),
                        TimeZone = profile.TimeZone
                    })).ToList();
