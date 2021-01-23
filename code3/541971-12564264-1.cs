    var query = DBConn.myView
                  .Where(dm => dm.TypeID != 4)
                  .Select(dm => new App.DTOs.MyDTO
                                {
                                    ID = dm.ID,
                                    Prop1 = dm.Prop1
                                    ....
                                });
                                
