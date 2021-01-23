        private void yourUltraGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // Define Global settings like you usually do
            // ....
            // Configure your UltraGrid columns.
            //// ID
            //// Caption: "ID"
            e.Layout.Bands[0].Columns[ColumnKeyA].Header.Caption = "ID";
            e.Layout.Bands[0].Columns[ColumnKeyA].Header.VisiblePosition = 0;
            e.Layout.Bands[0].Columns[ColumnKeyA].Width = 50;
            // Any additional settings you may want for this column.
            // Repeat for each column...
            // Then add this block under each column you want to add Summary value to.
            // This if function is critical to avoid summary rows from duplicating itself.
            // Check to see if the Summary does not exist.
            if (!e.Layout.Bands[0].Summaries.Exists("yourSummaryKey"))
            {
                // If it doesn't exist, create the summary.
                SummarySettings summary;
                summary = e.Layout.Bands[0].Summaries.Add("yourSummaryKey", SummaryType.Sum,
                    e.Layout.Bands[0].Columns[ColumnKeyA]);
                // Change the Display Formatting if you desire.
                // This display format will change it to just numbers
                // instead of "Sum = 1234"
                summary.DisplayFormat = "{0}";
                // Change the horizontal alignment for the cell text.
                summary.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // Apply any other settings to this summary column
                // if needed.
                // ...
            }
        }
