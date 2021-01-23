    static void Main(string[] args)
    {
        ACL aclItems = ACL.Create | ACL.Edit | ACL.Execute;
    
        var aclItemsString = aclItems.ToString();
        // aclItemsString value is "Create, Edit, Execute"
    
        ACL aclItemsOut;
        if (Enum.TryParse(aclItemsString, out aclItemsOut))
        {
            var areEqual = aclItems == aclItemsOut;
        }
    }
