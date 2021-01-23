    public class RestrictedComboBoxItemValidationRule : ValidationRule {
            private DataTable itemsSource;
            private ComboBox sender;
            private bool firstChance;
            public RestrictedComboBoxItemValidationRule(ComboBox sender) {
                this.sender = sender;
                this.firstChance = true;
                this.sender.LostFocus += new RoutedEventHandler(Invalidate_OnLostFocus);
                this.itemsSource = this.GetItemsSource (sender.ItemsSource);
                if (this.itemsSource != null) {
                    this.itemsSource.CaseSensitive = false; } }
    
            public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
                ValidationResult result = ValidationResult.ValidResult;
                if (!string.IsNullOrEmpty(value as string) && this.itemsSource != null) {
                    DataRow[] r = this.itemsSource.Select
                        (this.sender.SelectedValuePath + " = '" + value.ToString() + "'");
                    if (r.Length == 0 && (!this.sender.IsKeyboardFocusWithin || !this.firstChance)) {
                        result = new ValidationResult
                            (false, "The entered value is not in list!"); } }
                return result; }
    
            void Invalidate_OnLostFocus(object sender, RoutedEventArgs e) {
                Debug.Assert (((SWC.ComboBox)e.Source).Equals(this.sender),
                    "Sender-Object invalide!");
                this.Invalidate(false); }
    
            /// <param name="firstChance">true, if we want to wait for LostFocus (for our ComboBox),
            /// false, if user's inputs now should be checked.
            /// null, if no update of the firstChance-flag should occur</param>
            private void Invalidate(bool? firstChance) {
                if ((this.sender.IsEditable) && (!this.sender.IsReadOnly) &&
                    (!this.sender.IsKeyboardFocusWithin) && (!string.IsNullOrEmpty(this.SenderText))) {
                    if (firstChance.HasValue) {
                        this.firstChance = firstChance.Value; }
                    // force validation of sender-Object -> with ValidationResult Validate
                    this.sender.GetBindingExpression
                        (ComboBox.TextProperty).UpdateSource(); } }
    
            private DataTable GetItemsSource
                (object itemsSource) {
                    DataTable table = null;
                if (itemsSource.GetType() == typeof(DataTable)) {
                    table = itemsSource as DataTable; 
                }
                if (itemsSource.GetType() == typeof(DataView)) {
                    table = ((DataView)itemsSource).ToTable(); 
                }
                Debug.Assert(table != null,
                    "Unknown source type " + itemsSource.GetType ().Name);
                return table; } 
    
            private string SenderText {
                get { var text = (this.sender != null) ? this.sender.Text : string.Empty;
                    if (text == null) { text = string.Empty; }
                    return text.ToString().Trim(); } }
        } 
