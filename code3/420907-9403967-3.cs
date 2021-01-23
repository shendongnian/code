    public partial class MyAppContext 
    {
        /// <summary>
        /// Performs all 'post creation' operations for the MyAppContext 
        /// 
        /// *********************************
        /// NOTE: If you get a compiler error:
        /// 'No defining declaration found for implementing declaration of partial method 'OnContextCreated()'	
        /// then it is likely that the partial class MyApp.Context.cs does not contain a corresponding
        /// definition for the partial method OnContextCreated().
        /// This can occur if the MyApp.Context.tt template no longer generates the definition.
        /// SOLUTION: Edit the MyApp.Context.tt T4 template to ensure that that partial method is defined AND
        /// that it is called from EACH MyAppContext() constructor.
        /// *********************************
        /// 
        /// </summary>
        partial void OnContextCreated()
        {
            // Register the event handler
            this.Connection.StateChange += Connection_StateChange;
        }
    }
