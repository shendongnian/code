    // inside the UserControl's Page_Load method
    if (this.Visible)
    {
        // The user is an Admin, do whatever is needed (access database, databind, ...)
        ...
    }
    else
    {
        // The user is a Member, this UserControl is not used, do nothing.
    }
