     public override void OnLoad(Object sender, EventArgs e) {
          if( Page.IsPostBack ) {
              Validate();
              if( Page.IsValid ) {
                  // get values from a POST
                  String street = this.Address.Street.Value;
                  String city   = this.Address.City.Value;
                  // and so on
              }
          } else {
              // set values if you're retrieving data from a DB or something
              this.Address.Street.Value = "123 Fake Street";
              this.Address.City.Value = "Frying Pan City";
          }
     }
