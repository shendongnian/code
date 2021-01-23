    var result = from a in Context.DGApprovedLink 
                 join h in Context.DGHost on a.HostID equals h.ID
                 join c in Context.DGConfig on a.ResponseCode equals c.SubType
                 where c.Type == "HTTP Status"
                 select new {
                     a.ID,
                     a.HostID,
                     h.URL,
                     a.SourceURL,
                     a.TargetURL,
                     c.Value,
                     a.ExtFlag };
