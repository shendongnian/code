    var m = new MaterialModelContainer();
                var list = (from x in 
    
                           (from inv in m.INVs
                            where inv.NEW_QTY == "000000"
                            join lib in m.LIBs on inv.MESC equals lib.MESC
                            join tt1 in m.TRAN_TT1 on inv.MESC equals tt1.MESC4
                            where tt1.TYPE2 == "60" && tt1.QTY == "000000" 
                            select new {inv.MESC, lib.LINE_NO, lib.UNIT_LINE, Description = lib.DES + " " + lib.PART_NO, tt1.ACTD})
    
                            group by new {x.MESC, x.LINE_NO, x.UNIT_LINE, x.Description} into g
                            select new {g.Key.MESC, g.Key.LINE_NO, g.Key.UNIT_LINE, g.Key.Description, ACTDMax = g.Max(tt2 => tt2.ACTD) } );
