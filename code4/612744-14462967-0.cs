    routes.MapRoute(
           "VoucherPreviewNdddewUser", // Route name
           "Home/VoucherBusinessUserEntry/{ID}/{TokenID}", // URL with parameters
           new { controller = "Home", action = "VoucherBusinessUserEntry", id = 0, TokenID = Guid.NewGuid() } // Parameter defaults
           );
    routes.MapRoute(
                "Regdfsdfsdf", // Route name
                "LoginReg/Register/{UserTrackingID}/{IsFromScript}", // URL with parameters
                new { controller = "LoginReg", action = "Register", UserTrackingID = System.Guid.Empty
                    ,isfromscript = System.Boolean.FalseString 
                } // Parameter defaults
