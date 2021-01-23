    XNamespace itemNs = "urn:schema:Microsoft.Rtc.Management.ScopeFramework.2008";
    XNamespace assignmentNs = "urn:schema:Microsoft.Rtc.Management.Settings.ServiceAssignment.2008";
    var query =
        from item in doc.Descendants(itemNs + "Item")
        from assignment in item.Descendants(assignmentNs + "ServiceAssignment")
        select (long)assignment.Attribute("TagId");
