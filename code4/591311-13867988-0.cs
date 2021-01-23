        private void btnSaveLayout_Click ( object sender, EventArgs e ) {
			// show dialog to choose file
			if ( saveFileDialog1.ShowDialog ( this ) == DialogResult.OK ) {
				// open file stream
				System.IO.FileStream fileLayout = new System.IO.FileStream ( saveFileDialog1.FileName, System.IO.FileMode.OpenOrCreate );
				// reset position
				fileLayout.Seek ( 0, System.IO.SeekOrigin.Begin );
				// write layout
				this.ultraGrid.DisplayLayout.Save ( fileLayout,
					Infragistics.Win.UltraWinGrid.PropertyCategories.AppearanceCollection
					| Infragistics.Win.UltraWinGrid.PropertyCategories.ColumnFilters
					| Infragistics.Win.UltraWinGrid.PropertyCategories.Groups
					| Infragistics.Win.UltraWinGrid.PropertyCategories.SortedColumns
					| Infragistics.Win.UltraWinGrid.PropertyCategories.Summaries
					| Infragistics.Win.UltraWinGrid.PropertyCategories.ColScrollRegions
				);
				// close stream
				fileLayout.Close ();
			}
		}
    
        private void btnLoadLayout_Click ( object sender, EventArgs e ) {
			// show dialog to choose file
			if ( openFileDialog1.ShowDialog ( this ) == DialogResult.OK ) {
				// open file stream
				System.IO.FileStream fileLayout = new System.IO.FileStream ( openFileDialog1.FileName, System.IO.FileMode.Open );
				// reset position
				fileLayout.Seek ( 0, System.IO.SeekOrigin.Begin );
				// load layout
				this.ultraGrid.DisplayLayout.Load ( fileLayout,
					Infragistics.Win.UltraWinGrid.PropertyCategories.AppearanceCollection
					| Infragistics.Win.UltraWinGrid.PropertyCategories.ColumnFilters
					| Infragistics.Win.UltraWinGrid.PropertyCategories.Groups
					| Infragistics.Win.UltraWinGrid.PropertyCategories.SortedColumns
					| Infragistics.Win.UltraWinGrid.PropertyCategories.Summaries
					| Infragistics.Win.UltraWinGrid.PropertyCategories.ColScrollRegions
				);
				// close stream
				fileLayout.Close ();
			}
		}
