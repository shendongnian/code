    public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
    {
        base.PrepareForSegue (segue, sender);
        // do first a control on the Identifier for your segue
        if (segue.Identifier.Equals("your_identifier")) {
            
            var viewController = (CustomerViewController)segue.DestinationViewController;
    	    viewController.MyData = dataToInject;
        }
    }
