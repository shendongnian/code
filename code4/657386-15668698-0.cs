    // Parent ASPX
    <uc1:ChildControl runat="server" ID="cc1" OnSomeEvent="cc1_SomeEvent" />
    // Parent
    protected void cc1_SomeEvent(object sender, EventArgs e)
    {
        // Handler event
    }
    
    // Child
    public event EventHandler OnSomeEvent;
    
    protected void ErrorOccurInControl()
    {
         if (this.OnSomeEvent != null)
         {
              this.OnSomeEvent(this, new EventArgs());
         }
    }
    
    protected override void OnLoad(EventArgs e)
    {
         ErrorOccurInControl();
    }
