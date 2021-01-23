      public Address PrimaryAddress {
         get => return _primaryAddress;
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
               AddressChanged(object sender, PropertyChangedEventArgs args) 
                   => OnPropertyChanged("PrimaryAddress");
            }
      }
