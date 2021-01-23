		private void From1_Closing ( object sender , FormClosingEventArgs e )
		{
			if (this.CausesValidation )
			{   // There is no sense repeating this procedure if another routine already did it.
				DisableValidation ( );
			}	// if (this.CausesValidation )			
			if ( _fExceptionIsFatal )
			{	// Cancel False == Allow form to close.
				e.Cancel = false;
			}	// if ( _fExceptionIsFatal )
		}	// From1_Closing
