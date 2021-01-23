    ...
    public static readonly DependencyProperty FieldsProperty =
    	DependencyProperty.RegisterAttached("Fields", typeof(ObservableCollection<FormField>), typeof(Form), new PropertyMetadata(_fieldsListUpdated));
    ...
    // PropertyMetaData-callback for when the FieldsProperty is updated
    protected static void _fieldsListUpdated(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
    	foreach (FormField field in ((Form)sender).Fields) {
    		// check to see if the current field has valid operators
    		if ((field.Operators != null) && (field.Operators.Count > 0)) {
    			Dispatcher.CurrentDispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, (Action)(() => {
    				// set the current field's SelectedOperator to the first in the list
    				field.SelectedOperator = field.Operators[0];
    			}));
    		}
    	}
    }
