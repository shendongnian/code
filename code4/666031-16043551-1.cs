    foreach (MemberInfo memberInfo in membersInfo)
    {
        foreach (object attribute in memberInfo.GetCustomAttributes(true))
        {
            if (attribute is ReportAttribute)
            {
                if (((ReportAttribute)attribute).FriendlyName.Length > 0)
                {
                   treeItem.Items.Add(new TreeViewItem() { Header = ((ReportAttribute)attribute).FriendlyName });
                }
            }
            //if memberInfo.GetUnderlyingType() == specificType ? proceed...
        }
    }
