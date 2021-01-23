     if (StartDate.HasValue) query = query.Where(a => a.Time >= StartDate);
            if (EndDate.HasValue) query = query.Where(a => a.Time <= EndDate);
            if (!string.IsNullOrEmpty(OSVersion)) query = query.Where(a => a.App.Version == OSVersion);
            if (!string.IsNullOrEmpty(OSName)) query = query.JoinAlias(()=>appEventAlias.App,()=>appAlias).Where(()=>appAlias.OperatingSystemName==OSName);
            if (!string.IsNullOrEmpty(Model)) query = query.JoinAlias(()=>appEventAlias.Client, ()=>clientAlias).Where(()=>clientAlias.Id==appEventAlias.Client.Id).JoinAlias(()=>clientAlias.ClientInfos, () => clientInfoAlias).Where(()=>clientInfoAlias.DeviceModel == Model);
            
