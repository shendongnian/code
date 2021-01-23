    using (LiteralControl ltlText = new LiteralControl())
    {
        ltlText.Text = displayName;
        cellAssociate.Controls.Add(ltlText);
    }
    // could become
    cellAssociate.Controls.Add( new LiteralControl { Text = displayName } );
