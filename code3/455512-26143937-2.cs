    protected override void LoadValues(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
    {
    	
    	bool bAdd = true;
    	Control thisCtl = null;
    
    	Collection<Control> tCollection = (Collection<Control>)value;
    
    	foreach (object obj in context.Container.Components) {
    		//Cycle through the components owned by the form in the designer
    		bAdd = true;
    
    		// exclude other components - this weeds out DataGridViewColumns which
    		// can only be used by a DataGridView
    		if (obj is Control) {
    			thisCtl = (Control)obj;
    
    			if (ExcludeForm) {
    				bAdd = !(thisCtl is Form);
    			}
    
    			// custom exclude list 
    			if ((typeExclude != null) && (typeExclude.Count > 0)) {
    				if (typeExclude.Contains(thisCtl.GetType)) {
    					bAdd = false;
    				}
    			}
    
    			bool bCheck = false;
    			int ndx = 0;
    			if (bAdd) {
    				bCheck = tCollection.Contains(thisCtl);
    
    				ndx = myCtl.Items.Add(new ListItem(thisCtl));
    				myCtl.SetItemChecked(ndx, bCheck);
    			}
    		}
    
    	}
    
    }
