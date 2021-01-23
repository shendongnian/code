    public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
    		{
                base.PrepareForSegue(segue, sender);
    
                if (segue.Identifier.Equals("my Segue ID"))
                {
                    var viewController = (MyDestinationViewController)segue.DestinationViewController;
                    viewController.selectedItemInDestinationController = selectedControlStringFromViewController;
                }
    		}
