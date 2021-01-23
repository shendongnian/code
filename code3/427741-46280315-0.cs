    void AdaptColumnHeaderText(DataGridViewColumn column, bool autoSize=false)
    {
        //Supress column width events
        if (dataGridViewColumnWidthEventHandlers.ContainsKey(column.DataGridView))
        {
            dataGridView1.ColumnWidthChanged -= dataGridViewColumnWidthEventHandlers[column.DataGridView];
        }
        //Save initial column with as preferred
        var w_preferred = column.Width;
        if (
                column.SortMode.Equals(DataGridViewColumnSortMode.Automatic) &&
                column.HeaderCell.Style.Alignment.Equals(DataGridViewContentAlignment.MiddleCenter))
        {
            //remove all header padding
            column.HeaderCell.Style.Padding = new Padding(0, 0, 0, 0);
            //Fit column width to header text with AND sort glyph
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                
            //save column width sort enabled
            var w_sort = column.Width;
            //Fit column width to header text with NO sort glyph
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //save column width when sort disable
            var w_nosort = column.Width;
            //Calculate width consumed by sort glyph
            var w_glyph = w_sort - w_nosort;
            //Nominal column width if glyph width applied left and right of header text
            var w_nominal = w_glyph + w_nosort + w_glyph;
            //Disable column width autosize
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //Enable column autosorting
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            //If autosize option - ignore preferred width and set to nominal
            if (autoSize)
            {
                w_preferred = w_nominal;       
            }
            //Pad depending on final column width
            if (w_preferred >= w_nominal)
            {
                //Preferred width greater than nominal - pad left of text to balance width used by glyph
                column.HeaderCell.Style.Padding = new Padding(w_glyph, 0, 0, 0);
            }
            else
            {
                //Two symetric glyphs will not fit - pad left and right to supress glyph  
                w_glyph = (w_preferred - w_nosort) / 2;
                column.HeaderCell.Style.Padding = new Padding(w_glyph, 0, w_glyph, 0);
            }
            column.Width = w_preferred;
            
            Console.WriteLine("name:{0}, glyph:{1}, w_preferred:{2}", column.Name, w_glyph, w_preferred);
        }
        //re-enable column width events
        if (dataGridViewColumnWidthEventHandlers.ContainsKey(column.DataGridView))
        {
            dataGridView1.ColumnWidthChanged += dataGridViewColumnWidthEventHandlers[column.DataGridView];
        }
        
        
    }
 
