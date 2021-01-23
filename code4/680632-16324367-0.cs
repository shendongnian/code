    var Test= ve.Folders
                .Where(a => a.Collateral!= true)
                .Select(p => new 
                {
                    id = p.Folder_Id,
                    name = p.Full_Name,
                    add = p.Address,
                    date1 = p.Collateral_Date,
                    sName = p.Hosting._Name
                })
                .ToArray();
