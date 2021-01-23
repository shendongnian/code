    IQueryable<SubItem> childItems = context
        .SubItems.Include("Item")
        .Where(si => si.Id == 1 && si.Item.SomeAttr == someValue);
    //               ^^^^^^^^^^    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    //                   |                         |
    //                   |           Set a condition on the parent
    //  Set a condition on the child
