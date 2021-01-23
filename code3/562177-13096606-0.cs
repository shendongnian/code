    var rvClientRiskAdjs = (from ri in db.CI_CLIENTRISKADJS
                            join qb in
                                (from qb in db.QB_INVOICES_HEADER
                                 orderby qb.InvoiceDt ascending
                                 group qb by qb.ClientID into grp
                                 select new
                                 {
                                     InvoiceDt = grp.Max(s => s.InvoiceDt),
                                     ClientID = grp.Key
                                 })
                            on ri.ClientID equals qb.ClientID
                            where ri.IsActive == 1
                            select new ClientRiskModel()
                            {
                                ClientRiskId = ri.ClientRiskID,
                                ClientName = ri.CI_CLIENTLIST.ClientName,
                                ClientId = ri.ClientID,
                                ClientRiskAdjs = ri.ClientRiskAdjs,
                                RecordValidEnddt = ri.RecordValidEnddt,
                                RecordValidStartDt = ri.RecordValidStartDt,
                                InvoiceDt = qb.InvoiceDt
                            })
                            .OrderByDescending(o => o.InvoiceDt)
                            .ToList();
