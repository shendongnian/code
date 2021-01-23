    DataBase.PublicUserOfferingSignUps.Join(Database.PublicUsers, 
        puosu => puosu.PublicUserId,//PublicUserOfferingSignUps key
        pu => pu.Id,//PublicUser key
        (puosu, pu) => new {
            publicUsersOfferingSignUp = puosu,//we take all data from PubliUserOfferingSignUps
            puName = pu.Name//and Name from PublicUser
            })
    .OrderBy(x => x.puName)//we order by PublicUser Name
    .Select(x => x.publicUsersOfferingSignUp );//we take only the PublicOfferingSignUps
