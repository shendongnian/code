    // Unlike foreach, with for I can change the values in the list
    for (int i = 0; i < inventory.Count; i++)
    {
        if (mouseRectangle.Intersects(inventory[i].ItemRectangle))
        {
            if (Input.EdgeDetectLeftMouseDown())
            {
    			// You can replace the switch with this shorter structure
    			// if A is a bool value, !A will have the opposite value
    			inventory[i].ItemSelected = !inventory[i].ItemSelected;
            }  
        }
        else if (Input.EdgeDetectLeftMouseDown())
        {
    		// You don't need a case-switch for a single condition. An if should suffice
    		if (inventory[i].ItemSelected) 
    			inventory[i].ItemSelected = false;
        }
        else if (inventory[i].ItemSelected == true)
        {
            inventory[i].ItemPosition = new Vector2(mouseRectangle.X, mouseRectangle.Y);
            inventory[i].ItemRectangle = new Rectangle(mouseRectangle.X, mouseRectangle.Y, 32, 32);
        }
        else if (inventory[i].ItemSelected == false && //a lot of checks to determine it is not intersecting with an equip slot
        {
            inventory[i].ItemPosition = inventory[i].OriginItemPosition;
            inventory[i].ItemRectangle = inventory[i].OriginItemRectangle;
        }
    	
    	// Something definitely wrong with this line, a rectangle to instersect with itself??
        else if (inventory[i].ItemRectangle.Intersects(inventory[PROBABLY_SOMETHING_ELSE].ItemRectangle))
        {
            Swap (ref inventory[i], ref inventory[PROBABLY_SOMETHING_ELSE])
        }
    }
