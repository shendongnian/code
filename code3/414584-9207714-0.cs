    		public override void ViewDidLoad ()
		{
			Console.WriteLine ("Paged view did load");
			this.ContentSizeForViewInPopover = new SizeF (370, 670);
			
			var root = new RootElement ("Meals"){
			new Section ("Dinner"){
					new RootElement ("Desert", new RadioGroup ("desert", 2)){
						new Section (){
						new RadioElement ("Ice Cream", "desert"),
						new RadioElement ("Ice Cream", "desert"),
						new RadioElement ("Ice Cream", "desert"),
						new RadioElement ("Ice Cream", "desert"),
						new RadioElement ("Ice Cream", "desert")
						}
					}
				}		
			};
                        // This is the solution!
			var dv = new DialogViewController (root);
			View.Add(dv.View);
		}	
