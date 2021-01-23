    DirectoryInfo sourceDir = new DirectoryInfo(System.Web.HttpContext.Current.Request.MapPath("~/Content/ProductImages/" + Model.Products[i].ProductID.ToString() + "/thumbs/"));
    
    if (sourceDir.Exists)
    {
    	FileInfo[] fileEntries = sourceDir.GetFiles();
    	Array.Sort(fileEntries,
    		delegate(x, y)
    		{
    			String[] xvals = x.Name.Split('-');
    			String[] yvals = y.Name.Split('-');
    
    			int cmp = Int32.Parse(xvals[0]).CompareTo(Int32.Parse(yvals[0]));
    			if (cmp != 0)
    			{
    				return cmp;
    			}
    
    			cmp = Int32.Parse(xvals[1]).CompareTo(Int32.Parse(yvals[1]));
    			return cmp;
    		}
    	);
    }
