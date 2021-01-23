    DataBase.PublicUserOfferingSignUps.Join(Database.PublicUsers, 
        puosu => puosu.PublicUserId,
        pu => pu.Id,
        (puosu, pu) => new {
            publicUsersOfferingSignUps = puosu,
            puName = pu.Name
            })
    .OrderBy(x => x.puName)
    .Select(x => x.publicUsersOfferingSignUps );
