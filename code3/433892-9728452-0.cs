    private void tripsBindingSource_PositionChanged(object sender, EventArgs e)
    { 
        // something like
        if(dgvTripGrid.CurrentRow != null)
        {
            //get selected row index
            int index = this.dgvTripGrid.CurrentRow.Index;
            //get pk of selected row using index
            string cellValue = dgvTripGrid["pkTrips", index].Value.ToString();
            //change pk string to int
            int pKey = Int32.Parse(cellValue);
            ...
        }
    }
