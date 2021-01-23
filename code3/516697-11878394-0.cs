    // This prevents this window disposing when its close button is clicked by the
    // user; we want always show one and only one instance of this window.
    // But we still want to be able to close the form programmatically.
    FormClosing += (o, e) =>
        {
        	if (e.CloseReason == CloseReason.UserClosing)
    	    {
                Hide();
                e.Cancel = true;
            }
        };
