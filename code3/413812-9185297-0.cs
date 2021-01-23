	protected override void	OnDrawItem( DrawItemEventArgs e )
	{
		base.OnDrawItem( e );
		int			i=	e.Index;
		TabPage		p=	this.TabPages[ i ];
		Rectangle	r=	GetTabRect( i );
		Brush		br=	null;
		if(  this.Appearance != TabAppearance.Normal  &&  i == this.SelectedIndex  )
			br=	new HatchBrush( HatchStyle.Percent50, SystemColors.Control, SystemColors.Window );
		else
			br=	new SolidBrush( p.BackColor );
		try						// fill the BG-rectangle
		{	e.Graphics.FillRectangle( br, r );		}
		finally
		{	br.Dispose( );	}	// make sure brush is disposed of
		..	// the rest of the event-handler
	}
