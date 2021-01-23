            var list = (from x in
                            (
                                from inv in m.INVs
                                join l in m.LIBs on inv.MESC equals l.MESC
                                join o in m.OUTs on inv.MESC equals o.MESC
                                join t in m.TRANs on inv.MESC equals t.MESC
                                where t.TYPE == "60" && t.QTY!=""
                                select new
                                    {
                                        l.MESC,
                                        l.LINE_NO,
                                        l.UNIT_LINE,
                                        Description = l.DES + " " + l.PART_NO,
                                        inv.NEW_QTY,
                                        o.PJ,
                                        o.DATE,
                                        o.QTY,
                                        o.QTY_REC,
                                        TranQty = t.QTY,
                                        tranDate = t.DATE
                                    }
                            ).ToList()
                        group x by
                            new
                                {
                                    x.MESC,
                                    x.LINE_NO,
                                    x.UNIT_LINE,
                                    x.Description,
                                    x.NEW_QTY,
                                    x.PJ,
                                    x.DATE,
                                    x.QTY,
                                    x.QTY_REC
                                }
                        into g
                        select new
                            {
                                QTY_Consum_1 = g.Where(c => int.Parse(c.tranDate) >= cuDate && int.Parse(c.tranDate) <= endDate).Sum(d => int.Parse(d.TranQty)),
                               g.Key.MESC
                            }
                       ).ToList();
