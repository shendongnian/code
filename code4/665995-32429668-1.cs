		private void DisableValidation ( )
		{
			foreach ( Control ctrl in this.Controls )
			{
				ctrl.CausesValidation = false;
			}	// foreach ( Control ctrl in this.Controls )
			this.CausesValidation = false;
		}	// DisableValidation
