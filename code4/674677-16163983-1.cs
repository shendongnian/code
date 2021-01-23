	public string GetPermissions(ISubMenu submenu)
	{
		var menu_id = submenu.GetMenuId(); 
		//this is the only function you can call at the moment
		//since this is the only one we defined in the interface.
	}
	//Somewhere else in the code:
	var permissions = GetPermissions( new SubMenu1() );
