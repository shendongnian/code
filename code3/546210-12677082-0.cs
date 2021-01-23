    private ObservableCollection<ZoneResult> FindCommonZones(string[] searchterms)
    {
    
        var query = this.FabricDictionary.SelectMany(fabricpair => 
            fabricpair.Value.SelectMany(vsanpair => 
                vsanpair.Value.ActiveZoneSet.ZoneList
                .Where(z=>searchterms.Any(term=>z.ContainsMember(term)))
                .SelectMany(zone => 
                    zone.MembersList.Select(zm=>new ZoneResult(zone.zoneName, zm.MemberWWPN, zm.MemberAlias, vsanpair.Key.ToString()))
            )
        )
        .Distinct()
        .OrderBy(zr=>zr.zoneName);
    
        return new ObservableCollection<ZoneResult>(query);
    }
