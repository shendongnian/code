    // remove that line
    // for (int i = 0; i < products.Count; i++)
    int i = 0;
    {    
    	foreach (Product item in products)
    	{    
    		drow = dt.NewRow();
    		dt.Rows.Add(drow);
    		dt.Rows[i][col1] = item.ProductName.ToString();// i.ToString();
    		dt.Rows[i][col2] = item.ProductDescription.ToString();
    		dt.Rows[i][col3] = String.Format("{0:C}", item.Price);
    		dt.Rows[i][col4] = String.Format("{0:.00}", item.Price);
    		// and here move to next
    		i++;
    	}    
    }
