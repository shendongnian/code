    public ArrayList Groups(string userDn, bool recursive)
    {
        ArrayList groupMemberships = new ArrayList();
        return AttributeValuesMultiString("memberOf", userDn,
            groupMemberships, recursive);
    }
    public string AttributeValuesSingleString
        (string attributeName, string objectDn)
    {
        string strValue;
        DirectoryEntry ent = new DirectoryEntry(objectDn);
        strValue = ent.Properties[attributeName].Value.ToString();
        ent.Close();
        ent.Dispose();
        return strValue;
    }
    public string GetObjectDistinguishedName(objectClass objectCls,
        returnType returnValue, string objectName, string LdapDomain)
    {
        string distinguishedName = string.Empty;
        string connectionPrefix = "LDAP://" + LdapDomain;
        DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
        DirectorySearcher mySearcher = new DirectorySearcher(entry);
        switch (objectCls)
        {
            case objectClass.user:
                mySearcher.Filter = "(&(objectClass=user)
            (|(cn=" + objectName + ")(sAMAccountName=" + objectName + ")))";
                break;
            case objectClass.group:
                mySearcher.Filter = "(&(objectClass=group)
            (|(cn=" + objectName + ")(dn=" + objectName + ")))";
                break;
            case objectClass.computer:
                mySearcher.Filter = "(&(objectClass=computer)
                (|(cn=" + objectName + ")(dn=" + objectName + ")))";
                break;
        }
        SearchResult result = mySearcher.FindOne();
        if (result == null)
        {
            throw new NullReferenceException
            ("unable to locate the distinguishedName for the object " +
            objectName + " in the " + LdapDomain + " domain");
        }
        DirectoryEntry directoryObject = result.GetDirectoryEntry();
        if (returnValue.Equals(returnType.distinguishedName))
        {
            distinguishedName = "LDAP://" + directoryObject.Properties
                ["distinguishedName"].Value;
        }
        if (returnValue.Equals(returnType.ObjectGUID))
        {
            distinguishedName = directoryObject.Guid.ToString();
        }
        entry.Close();
        entry.Dispose();
        mySearcher.Dispose();
        return distinguishedName;
    }
