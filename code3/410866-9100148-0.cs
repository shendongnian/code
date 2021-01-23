    class Default : Page {
       enum LoadedControl { Textbox, Label, GridView }
       
       override OnInit() {
          if (IsPostback) {
            var c = Viewstate["LoadedControl"] as LoadedControl;
            if (c != null) LoadDynamicControl(c);
          }
       }
       void Button_Click() {
         var c = (LoadedControl)Enum.Parse(typeof(LoadedControl), ddl.SelectedValue);
         LoadDynamicControl(c);
       }
 
       void LoadDynamicControl(LoadedControl c) {
         switch (c) {
            case LoadedControl.Textbox:
               this.ph.Controls.Add(new Textbox());
               break;
            ...
         }
         ViewState["LoadedControl"] = c;
       }
    }
