     bool check(Control root,List<Control> nonFilled)
     {
	    bool result;
	   if (root is TextBox &&  string.isNullOrEmpty(((TextBox)root).Text)   )
	    {
	   	nonFilled.Add(root);
		return false;
	   }
	   foreach(Control c in root.Controls)
	   {
	   	result|=check(c,nonFilled)
	   }
	   return result;
     }
