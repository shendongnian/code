    public partial class mainForm : Form {
    	delegate void noParamsDelegate();
    	Stack<noParamsDelegate> methodsToCallWhenIdle = new Stack<noParamsDelegate>();
    	void application_Idle( object sender, EventArgs e ) {
    		if( methodsToCallWhenIdle.Count > 0 ) {
    			methodsToCallWhenIdle.Pop()(); // Call the deligate at the top of the stack
    		}
    	}
    	public mainForm() {
    		InitializeComponent();
    		Application.Idle += new EventHandler( application_Idle );
    		bindExampleDataToListBox();
    		listBox.KeyDown += new KeyEventHandler( listBox_KeyDown );
    	}
    	ListItems boundList = new ListItems();
    	void listBox_KeyDown( object sender, KeyEventArgs e ) {
    		if( e.Control && methodsToCallWhenIdle.Count == 0 ) {
    			if( e.KeyCode == Keys.Down ) {
				copyOfSelectedItems = createCopyOfSelectedItems();
    				methodsToCallWhenIdle.Push( moveSelectedDown );
    			}
    			if( e.KeyCode == Keys.Up ) {
    				copyOfSelectedItems = this.createCopyOfSelectedItems();
    				methodsToCallWhenIdle.Push( moveSelectedUp );
    			}
    		}
    	}
    	List<ListItem> copyOfSelectedItems = new List<ListItem>();
    	void moveSelectedDown() {
    		if( copyOfSelectedItems.Count > 0 ) {
    			boundList.MoveDown( copyOfSelectedItems );
    			restoreSelection( copyOfSelectedItems );
    		}
    	}
    	void moveSelectedUp() {
    		if( copyOfSelectedItems.Count > 0 ) {
    			boundList.MoveUp( copyOfSelectedItems );
    			restoreSelection( copyOfSelectedItems );
    		}
    	}
    	void restoreSelection( List<ListItem> selectedItems ) {
    		foreach( ListItem item in selectedItems ) {
    			listBox.SetSelected( listBox.Items.IndexOf( item ), true );
    		}
    	}
    	List<ListItem> createCopyOfSelectedItems() {
    		List<ListItem> result = new List<ListItem>();
    		foreach( ListItem listItem in listBox.SelectedItems ) {
    			result.Add( listItem );
    		}
    		return result;
    	}
    	void bindExampleDataToListBox() {
    		BindingSource bSrc = new BindingSource();
    		boundList = getExampleData();
    		bSrc.DataSource = boundList;
    		bSrc.Sort = "OrderValue DESC";
    		listBox.DataSource = bSrc;
    		listBox.DisplayMember = "TextValue";
    	}
    	ListItems getExampleData() {
    		ListItems result = new ListItems();
    		result.Add( new ListItem() { TextValue = "Item 1", OrderValue = 0 } );
    		result.Add( new ListItem() { TextValue = "Item 5", OrderValue = 4 } );
    		result.Add( new ListItem() { TextValue = "Item 3", OrderValue = 2 } );
    		result.Add( new ListItem() { TextValue = "Item 4", OrderValue = 3 } );
    		result.Add( new ListItem() { TextValue = "Item 2", OrderValue = 1 } );
    		return result;
    	}
    }
