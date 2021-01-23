    public void Page_Load() {
       if (IsPostBack) {
          if (ViewState["AddedControl"] != null) {
             // Re-create the control but do not
             // restore settings configured outside
             // the proc (i.e., MaxLength and BackColor)
             TextBox t = AddTextBox(); 
          }  
       }
    }
    public void OnClick(object sender, EventArgs e) {
       TextBox t = AddTextBox();
     
       // Modify properties outside the proc to
       // simulate generic changed to the
       // control's view state
       t.MaxLength = 5;
       t.BackColor = Color.Yellow;
    }
    
    public TextBox AddTextBox() {
       TextBox ctl = new TextBox();
       ctl.Text = "Hello";
       placeHolder.Controls.Add(ctl);
     
       // Records that a dynamic control has been added
       ViewState["AddedControl"] = "true";
       return ctl;
    }
