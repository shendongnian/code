        string sel = Listview1.SelectedItem.Text;
    string value = null;
    foreach ( con in Stackpanel.Controls) {
    	if ((con) is Textblock) {
    		if (con.Name == sel) {
    			value = ((con)Textblock).Text;
    			break; 
    		}
    	}
    }
