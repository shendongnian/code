    for(int i = 0; i < numberOfAnswers; i++){
        var ib = new ImageButton();
        var td = new HtmlTableCell();
        
        // assign values, like ID, Image URL, event handlers, etc. here
        ib.ID = "button_" + i;
        ib.ImageUrl = "foo";
        ib.Click += ( sender, e ) => {
            // anonymous event handler
        };
        // "container" can be any control on the page, such as a table row
        container.Controls.Add( td );
        td.Controls.Add( ib );
    }
