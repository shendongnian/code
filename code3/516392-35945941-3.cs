      public Address PrimaryAddress {
         get => _primaryAddress;
         set {
               if ( _primaryAddress != value ) 
               {
                 //Clean-up old event handler:
                 if(_primaryAddress != null)
                   _primaryAddress.PropertyChanged -= AddressChanged;
                 _primaryAddress = value;
                 if (_primaryAddress != null)
                   _primaryAddress.PropertyChanged += AddressChanged;
                 OnPropertyChanged( "PrimaryAddress" );
               }
               void AddressChanged(object sender, PropertyChangedEventArgs args) 
                   => OnPropertyChanged("PrimaryAddress");
            }
      }
