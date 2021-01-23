    var code = Request.QueryString["ControlCode"];
    
    var q = from accCo in db.AccControls
            join accCom in db.AccCompanies
            on new { accCo.ControlCode } equals
            new { ControlCode = accCom.Code }
    
            where accCo.ControlCode == code //EDIT
            orderby accCom.Code
            select new Combined{ AccControls = accCo, AccCompoanies = accCom };
