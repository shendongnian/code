    partial class MyAppContext
    {
            partial void OnContextCreated()
            {
                // Register the event handler
                this.Connection.StateChange += Connection_StateChange;
            }
            void Connection_StateChange(object sender, StateChangeEventArgs e) {
            
            }
    }
