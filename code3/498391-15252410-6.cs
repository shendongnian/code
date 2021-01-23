       var myInvestmentView = new InvestmentView
                                {
                                  Id = result.Id,
                                  Name = result.Name,
                                  Owner = new Person{ Id = result.firstOrDefault(o => o.INVTYPE.Equals("OwnerId")).PersonId, Name =  result.firstOrDefault(o=> o.INVTYPE.Equals("OwnerId")).PersonName},
                                  ITOwner  = new Person{ Id = result.firstOrDefault(o => o.INVTYPE.Equals("ITOwnerId")).PersonId, Name =  result.firstOrDefault(o=> o.INVTYPE.Equals("ITOwnerId")).PersonName},
                                  InformationOwner  = new Person{ Id = result.firstOrDefault(o => o.INVTYPE.Equals("InformationOwnerId")).PersonId, Name =  result.firstOrDefault(o=> o.INVTYPE.Equals("InformationOwnerId")).PersonName},
                                  MaintenanceLeader = new Person{ Id = result.firstOrDefault(o => o.INVTYPE.Equals("MaintenanceLeaderId")).PersonId, Name =  result.firstOrDefault(o=> o.INVTYPE.Equals("MaintenanceLeaderId")).PersonName},
                                  MaintenanceLeaderIT = new Person{ Id = result.firstOrDefault(o => o.INVTYPE.Equals("MaintenanceLeaderITId")).PersonId, Name =  result.firstOrDefault(o=> o.INVTYPE.Equals("MaintenanceLeaderITId")).PersonName}
                                }  
