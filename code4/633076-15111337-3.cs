    public partial class UserControl1 : UserControl
    {
        private List<RowDefinition> _rows; // rows in graphGrid
        private List<CheckBox> _visibilityCheckboxes; // checkboxes that determine graph visibilities
        private Dictionary<int, List<UIElement>> _elementsByRow = new Dictionary<int, List<UIElement>>(); // map of elements per row
        public UserControl1()
        {
            InitializeComponent();
            _visibilityCheckboxes = this.panelVisibilities.Children.OfType<CheckBox>().ToList();
            _rows = this.graphGrid.RowDefinitions.ToList();
            // create map of elements per row
            var elements = this.graphGrid.Children.Cast<UIElement>();
            for (int i = 0; i < _rows.Count; i++)
            {
                _elementsByRow.Add(i, elements.Where(e => Grid.GetRow(e) == i).ToList());
            }
            // check counts (optional)
            if (_rows.Count != _visibilityCheckboxes.Count)
                System.Diagnostics.Debug.WriteLine("Graph count does not match checkbox count.");
        }
        /// <summary>
        /// Handles the visibility checkboxes click.
        /// Adds/removes rows from the graphGrid, and adjusts the other elements accordingly.
        /// </summary>
        private void GraphVis_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chbx = sender as CheckBox;
            if (chbx != null && _visibilityCheckboxes.Contains(chbx))
            {
                int actualIndex = GetActualIndex(chbx); // row index at which the change occurs
                int originalIndex = _visibilityCheckboxes.IndexOf(chbx); // original index of the inserted row
                bool isChecked = (bool)chbx.IsChecked;
                RepositionControls(actualIndex, isChecked); 
                if (isChecked)
                {
                    this.graphGrid.RowDefinitions.Insert(actualIndex, _rows[originalIndex]); // add row
                    foreach (var element in _elementsByRow[originalIndex])
                        Grid.SetRow(element, actualIndex); // set element's grid.row to inserted row number
                }
                else
                    this.graphGrid.RowDefinitions.RemoveAt(actualIndex); // remove row
            }
        }
        /// <summary>
        /// Determines at which row number the change needs to occur.
        /// E.g. when checking chbx3, but only chbx1 is already checked (chbx2 is not), 
        /// the index of change (zero based) is 1 and not 2.
        /// </summary>
        /// <param name="chbx">Checkbox that was just changed</param>
        private int GetActualIndex(CheckBox chbx)
        {
            int i = 0;
            foreach (var c in _visibilityCheckboxes)
            {
                if (c == chbx) break;
                if ((bool)c.IsChecked) i++;
            }
            return i;
        }
        /// <summary>
        /// Moves elements to the appropriate grid row
        /// </summary>
        /// <param name="startIndex">Row number, at which the change occurs</param>
        /// <param name="isChecked">True if adding row, false when removing row</param>
        private void RepositionControls(int startIndex, bool isChecked)
        {
            if (!isChecked) startIndex++; // e.g. remove at row1 --> elements in row2, row3.. need to be adjusted
            // get all elements that need row adjustment (IsMeasureValid is false for non-displayed elements - is there a better property to use?)
            var elementsToMove = this.graphGrid.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) >= startIndex && e.IsMeasureValid);
            foreach (var element in elementsToMove)
            {
                // increase or decrease grid.row property
                Grid.SetRow(element, Grid.GetRow(element) + (isChecked ? 1 : -1)); 
            }
        }
    }
