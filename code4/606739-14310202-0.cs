            private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
            {
            	if (!char.IsControl(e.KeyChar)
            	    && !char.IsDigit(e.KeyChar)
            	    && e.KeyChar != '.')
            		e.Handled = true;
            	
            	// only allow one decimal point
            	if (e.KeyChar == '.'
            	    && (txtHours).Text.IndexOf('.') > -1)
            		e.Handled = true;
            }
   
