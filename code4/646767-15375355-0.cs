    public string FirstName {
     get { return this.txtFirst.Text.Trim(); }
     set { this.txtFirst.Text = value ?? ""; }
    }
    public string LastName {
     get { return this.txtLast.Text.Trim(); }
     set { this.txtLast.Text = value ?? ""; }
    }
