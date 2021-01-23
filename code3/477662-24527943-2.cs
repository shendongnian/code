    void drawFilledMidpointCircleSinglePixelVisit( int centerX, int centerY, int radius )	
	{
		int x = radius;
		int y = 0;
		int radiusError = 1 - x;
		while (x >= y)  // iterate to the circle diagonal
		{
			
			// use symmetry to draw the two horizontal lines at this Y with a special case to draw
			// only one line at the centerY where y == 0
			int startX = -x + centerX;
			int endX = x + centerX;			
			drawHorizontalLine( startX, endX, y + centerY );
			if (y != 0)
			{
				drawHorizontalLine( startX, endX, -y + centerY );
			}
			
			// move Y one line
			y++;
			
			// calculate or maintain new x
			if (radiusError<0)
			{
				radiusError += 2 * y + 1;
			} 
			else 
			{
				// we're about to move x over one, this means we completed a column of X values, use
				// symmetry to draw those complete columns as horizontal lines at the top and bottom of the circle
				// beyond the diagonal of the main loop
				if (x >= y)
				{
					startX = -y + 1 + centerX;
					endX = y - 1 + centerX;
					drawHorizontalLine( startX, endX,  x + centerY );
					drawHorizontalLine( startX, endX, -x + centerY );
				}
				x--;
				radiusError += 2 * (y - x + 1);
			}
			
		}
		
	}
