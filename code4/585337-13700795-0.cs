    (from MenuItem in menuContext.Menus
       where MenuItem.IsSysAdmin == ((ClientID == 1 )? true : false)
       && MenuItem.IsActive == true
       && MenuItem.ParentMenuCode == ( (ActiveSubMenu==null) ?null:ActiveMenu)
       && MenuItem.ClientID == (UseClientMenu ? ClientID : 0)
       && MenuItem.EmployeeID == (UseEmployeeMenu ? EmployeeID : 0)
       orderby MenuItem.SortOrder, MenuItem.MenuName
       select MenuItem);
