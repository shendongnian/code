    private void AllControlDesign2(ref Control TB)
    {
    	if (object.ReferenceEquals(TB.GetType, typeof(StatusStrip))) {
    		((TextBox)TB).ReadOnly = true;
    		TB.BackColor = stFromBackColour;
    		TB.ForeColor = Color.Gray;
    	}
    }
