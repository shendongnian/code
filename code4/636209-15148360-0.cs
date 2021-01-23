            private void portriatNavBar ()
    		{
    			//  _leftButton = new UIBarButtonItem("Calendars", UIBarButtonItemStyle.Bordered, HandlePreviousDayTouch);
    			NavigationItem.LeftBarButtonItem = _orgLefButton;
    			NavigationItem.Title = "Calendar";
    			_rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, delegate {
    				addController = new EKEventEditViewController ();	
    				// set the addController's event store to the current event store.
    				addController.EventStore = Util.MyEventStore;
    				addController.Event = EKEvent.FromStore(Util.MyEventStore);
    				addController.Event.StartDate = DateTime.Now;
    				addController.Event.EndDate = DateTime.Now.AddHours(1);
    				
    				addController.Completed += delegate(object theSender, EKEventEditEventArgs eva) {
    					switch (eva.Action)
    					{
    						case EKEventEditViewAction.Canceled :
    						case EKEventEditViewAction.Deleted :
    						case EKEventEditViewAction.Saved:
    						this.NavigationController.DismissModalViewControllerAnimated(true);
    						
    						break;
    					}
    				};
    
    				// Going to create a precursor to actually displaying the creation of a calendar event so we can grab everything correctly
    				RootElement _ctRoot = new RootElement ("Task Details") {
    					new Section () {
    						new RootElement ("Clients") {
    							AppSpecificNamespace.TaskController.GetClientsForCalendar ()
    						},
    						new RootElement ("Task Types") {
    							AppSpecificNamespace.TaskController.GetTypesForCalendar ()
    						}
    					},
    					new Section () {
    						new StyledStringElement ("Continue", delegate {
    							this.NavigationController.PopViewControllerAnimated (true);
    							this.NavigationController.PresentModalViewController (addController, true);
    						}) { Alignment = UITextAlignment.Center, TextColor = UIColor.Blue }
    					}
    				};
    				DialogViewController AppSpecificDVC = new DialogViewController (_ctRoot);
    				this.NavigationController.PushViewController (AppSpecificDVC, true);
    				//this.NavigationController.PresentViewController (AppSpecificDVC, true, null);
    			});
    			
    			NavigationItem.RightBarButtonItem = _rightButton;
    		}
