    public class EventListingElement2 : Element , IElementSizing
    {
    	EventListingItem _ev;
    	
    	public EventListingElement2 (EventListingItem item) : base ("")
    	{
    		_ev = item;
    	}
    	
    	public override MonoTouch.UIKit.UITableViewCell GetCell (MonoTouch.UIKit.UITableView tv)
    	{
    		MyDataCell ret = tv.DequeueReusableCell ("xcx") as MyDataCell;
    		if (ret == null) {
    			ret = new MyDataCell (_ev, "xcx");
    		}
    		else {
    			 ret.UpdateCell (_ev);
    		}
    		
    		return ret;
    	}
    	
    	public override void Selected (DialogViewController dvc, UITableView tableView, MonoTouch.Foundation.NSIndexPath path)
    	{
    		base.Selected (dvc, tableView, path);
    	}
    
    	#region IElementSizing implementation
    	public float GetHeight (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
    	{
    		return 90;
    	}
    	#endregion
    }
    
    
    public class MyDataView : UIView
    {
    	public MyDataView (EventListingItem myData)
    	{
    		Update (myData);
    		this.BackgroundColor = UIColor.Clear;
    	}
    
    	public void Update (EventListingItem myData)
    	{
    		this._ev = myData;
    		SetNeedsDisplay ();
    	}
    	
    	EventListingItem _ev = new EventListingItem ();
    	
    	public override void Draw (RectangleF rect)
    	{
    		SizeF sizeF;
    		float num = 0f;
    		UIColor.FromRGB (36, 112, 216).SetColor ();
    		string dateStr;
    		if (_ev.StartTime.HasValue) {
    			TimeSpan t = DateTime.Now - _ev.StartTime.Value;
    			if (DateTime.Now.Day == _ev.StartTime.Value.Day) {
    				dateStr = _ev.StartTime.Value.ToShortTimeString ();
    			} else {
    				if (t <= TimeSpan.FromHours (24.0)) {
    					dateStr = "Yesterday"; //.GetText ();
    				} else {
    					if (t < TimeSpan.FromDays (6.0)) {
    						dateStr = _ev.StartTime.Value.ToString ("dddd");
    					} else {
    						dateStr = _ev.StartTime.Value.ToShortDateString ();
    					}
    				}
    			}
    		} else {
    			dateStr = "Date TBA";
    		}
    		// Setup counts
    		string counts = "Staff & Volunteers: {0} reg, {1} in, {2} out\n";
    		counts += "Students & Visitors: {3} reg, {4} in, {5} out";
    		counts = string.Format (
    			counts,
    			_ev.CountOfStaffAndVolunteersRegistered,
    			_ev.CountOfStaffAndVolunteersCheckedIn,
    			_ev.CountOfStaffAndVolunteersCheckedOut,
    			_ev.CountOfStudentsAndVisitorsRegistered,
    			_ev.CountOfStudentsAndVisitorsCheckedIn,
    			_ev.CountOfStudentsAndVisitorsCheckedOut
    		);
    
    		float left = 13f;
    
    		// Draw
    		sizeF = this.StringSize (dateStr, EventListingElement.EventTitleFont);
    		float num2 = sizeF.Width + 21f + 5f;
    		RectangleF dateFrame = new RectangleF (
    			this.Bounds.Width - num2,
    			6f,
    			num2,
    			14f
    		);
    
    		this.DrawString (
    			dateStr,
    			dateFrame,
    			EventListingElement.DatesFont,
    			UILineBreakMode.Clip,
    			UITextAlignment.Left
    		);
    		float num3 = this.Bounds.Width - left;
    		UIColor.Black.SetColor ();
    		if (!string.IsNullOrWhiteSpace (_ev.EventType)) {
    			this.DrawString (
    				_ev.EventType,
    				new PointF (left, 2f),
    				num3 - num2,
    				EventListingElement.EventTypeFont,
    				UILineBreakMode.TailTruncation
    			);
    		}
    		this.DrawString (
    			_ev.Name,
    			new PointF (left, 23f),
    			num3 - left - num,
    			EventListingElement.EventTitleFont,
    			UILineBreakMode.TailTruncation
    		);
    		UIColor.Gray.SetColor ();
    		this.DrawString (
    			counts,
    			new RectangleF (left, 40f, num3 - num, 34f),
    			EventListingElement.CountsFont,
    			UILineBreakMode.TailTruncation,
    			UITextAlignment.Left
    		);
    	}
    		
    }
    
    public class MyDataCell : UITableViewCell
    {
    	MyDataView _myDataView;
    
    	public MyDataCell (EventListingItem myData, string identKey) : base (UITableViewCellStyle.Default, identKey)
    	{
    		_myDataView = new MyDataView (myData);
    		ContentView.Add (_myDataView);
    	}
    
    	public override void LayoutSubviews ()
    	{
    		base.LayoutSubviews ();
    		_myDataView.Frame = ContentView.Bounds;
    		_myDataView.SetNeedsDisplay ();
    	}
    
    	public void UpdateCell (EventListingItem myData)
    	{
    		_myDataView.Update (myData);
    	}
    }
