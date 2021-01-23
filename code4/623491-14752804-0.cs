    var q = from accCo in db.AccControls
            join accCom in db.AccCompanies.DefaultIfEmpty()
            on new { accCo.ControlCode } equals
            new { ControlCode = accCom.Code }
    
            where accCo.ControlCode == Request.QueryString["ControlCode"]
            orderby accCom.Code
            select new Combined{ AccControls = accCo, AccCompoanies = accCom };
