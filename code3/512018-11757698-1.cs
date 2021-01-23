    for(int i = 0; i < numberOfAnswers; i++){
        var ib = new ImageButton();
        var td = new HtmlTableCell();
        // "container" can be any control on the page, such as a table row
        container.Controls.Add( td );
        td.Controls.Add( ib );
    }
