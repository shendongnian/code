    String displayMessage;    
    public String DisplayMessage {
          get { return displayMessage; }
          set { if (value != displayMessage) {
                  displayMessage = value;
                  PropertyChanged("DisplayMessage");
                }
          }
        }
