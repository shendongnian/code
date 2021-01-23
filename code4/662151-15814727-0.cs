    Connection newConnection = new Connection
    {
        Record1Id = new EntityReference(Account.EntityLogicalName,
            _accountId),
        Record1RoleId = new EntityReference(ConnectionRole.EntityLogicalName,
            _connectionRoleId),                             
        Record2RoleId = new EntityReference(ConnectionRole.EntityLogicalName,
            _connectionRoleId),                            
        Record2Id = new EntityReference(Contact.EntityLogicalName,
            _contactId)
    };
    _connectionId = _serviceProxy.Create(newConnection);
