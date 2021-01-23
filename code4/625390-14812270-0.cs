    string html;
    int lastLevel = 0;
    void placeMenu( int parentID, int level, Menu menu )
    {
        // when going down tree add extra level to <UL>
        if( lastLevel > level ) html += "<ul>";
    
        // add current menu item
        html += "<li><a href='http://link/to/page'" + menu.Name + "</a></li>";
        // when going back up the tree close the UL
        if( lastLevel < level ) html += "</ul>";
    }
    
    void setupMenu( Menu menu, int level )
    {
        foreach( var currentMenu in parentMenu._ChildMenus )
        {
            // place current menu
            placeMenu( currentMenu, level + 1 );
            // place submenus
            setupWholeMenu( currentMenu, level + 1 );
        }
    }
    string setupWholeMenu( Menu menu )
    {
        setupWholeMenu( menu, 0 );
        return html;
    }
