	using MonoTouch.Foundation;
	using MonoTouch.UIKit;
	using System;
	using System.Drawing;
	namespace MonoTouch.Dialog
	{
		public class NullableDateTimeElement : StringElement
		{
			private class MyViewController : UIViewController
			{
				private NullableDateTimeElement container;
				private bool hasNullValue = false;
				private bool hasBeenSet = false;
				//private EventHandler nullButtonTouched;
				//UIButton isNullButton;
				public bool Autorotate
				{
					get;
					set;
				}
				public MyViewController (NullableDateTimeElement container)
				{
					this.container = container;
				}
				public override void ViewDidLoad ()
				{
					base.ViewDidLoad ();
					//isNullButton = UIButton.FromType (UIButtonType.RoundedRect);
					//isNullButton.SizeToFit ();
					//isNullButton.Frame = new RectangleF(this.View.Frame.Top, this.View.Frame.Left, this.View.Frame.Width - 40f, 40f);
					//isNullButton.SetTitle (container.NullButtonCaption, UIControlState.Normal);
					this.NavigationItem.RightBarButtonItems = new UIBarButtonItem[]
					{
						new UIBarButtonItem(container.NullButtonCaption, UIBarButtonItemStyle.Done, NullButtonTapped),
						new UIBarButtonItem(container.SetButtonCaption, UIBarButtonItemStyle.Done, SetButtonTapped)
					};
					this.NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, CancelTapped);
					this.NavigationItem.HidesBackButton = true;
					//this.View.AddSubview (isNullButton);
					//this.isNullButton.TouchUpInside += (nullButtonTouched = new EventHandler(nullButtonWasTouched)); 
				}
				
				void CancelTapped(object sender, EventArgs e)
				{
					hasBeenSet = false;
					this.NavigationController.PopViewControllerAnimated (true);
				}
				
				void NullButtonTapped(object sender, EventArgs e)
				{
					hasBeenSet = true;
					hasNullValue = true;
					this.NavigationController.PopViewControllerAnimated (true);
				}
				
				void SetButtonTapped(object sender, EventArgs e)
				{
					hasBeenSet = true;
					hasNullValue = false;
					this.NavigationController.PopViewControllerAnimated (true);
				}
				
				public override void ViewWillDisappear (bool animated)
				{
					base.ViewWillDisappear (animated);
					if (hasBeenSet)
					{
						if (!hasNullValue)
							this.container.DateValue = this.container.datePicker.Date;
						else
							this.container.DateValue = null;
					}
					//this.isNullButton.TouchUpInside -= nullButtonTouched;
					//nullButtonTouched = null;
				}
				/*void nullButtonWasTouched(object sender, EventArgs e)
				{
					hasNullValue = true;
					NavigationController.PopViewControllerAnimated (true);
				}*/
				public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
				{
					base.DidRotate (fromInterfaceOrientation);
					this.container.datePicker.Frame = NullableDateTimeElement.PickerFrameWithSize (this.container.datePicker.SizeThatFits (SizeF.Empty));
				}
				public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
				{
					return this.Autorotate;
				}
			}
			public DateTime? DateValue;
			public UIDatePicker datePicker;
			//public UIButton isNullButton;
			public string NullButtonCaption { get; set; }
			public string SetButtonCaption { get; set; }
			
			protected internal NSDateFormatter fmt = new NSDateFormatter
			{
				DateStyle = NSDateFormatterStyle.Short
			};
			
			public NullableDateTimeElement (string caption, DateTime? date, string nullButtonCaption, string setButtonCaption) : base (caption)
			{
				this.DateValue = date;
				this.Value = this.FormatDate (date);
				this.NullButtonCaption = nullButtonCaption;
				this.SetButtonCaption = setButtonCaption;
			}
			
			public NullableDateTimeElement(string caption, DateTime? date, string nullButtonCaption) : this(caption, date, nullButtonCaption, "Set Date")
			{}
			
			public NullableDateTimeElement(string caption, DateTime? date) : this(caption, date, "No Date", "Set Date")
			{}
			
			public override UITableViewCell GetCell (UITableView tv)
			{
				this.Value = this.FormatDate (this.DateValue);
				UITableViewCell cell = base.GetCell (tv);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}
			protected override void Dispose (bool disposing)
			{
				base.Dispose (disposing);
				if (disposing)
				{
					if (this.fmt != null)
					{
						this.fmt.Dispose ();
						this.fmt = null;
					}
	/*				if (this.isNullButton != null)
					{
						this.isNullButton.Dispose ();
						this.isNullButton = null;
					}*/
					if (this.datePicker != null)
					{
						this.datePicker.Dispose ();
						this.datePicker = null;
					}
				}
			}
			public virtual string FormatDate (DateTime? dt)
			{
				if (dt.HasValue)
					return this.fmt.ToString (dt.Value) + " " + dt.Value.ToLocalTime ().ToShortTimeString ();
				else
					return NullButtonCaption;
			}
			public virtual UIDatePicker CreatePicker ()
			{
				return new UIDatePicker (RectangleF.Empty)
				{
					AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
					Mode = UIDatePickerMode.DateAndTime,
					Date = this.DateValue ?? DateTime.Now
				};
			}
			private static RectangleF PickerFrameWithSize (SizeF size)
			{
				RectangleF applicationFrame = UIScreen.MainScreen.ApplicationFrame;
				float y = 0f;
				float x = 0f;
				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
					case UIInterfaceOrientation.PortraitUpsideDown:
						{
							x = (applicationFrame.Width - size.Width) / 2f;
							y = (applicationFrame.Height - size.Height) / 2f - 25f;
							break;
						}
					case UIInterfaceOrientation.LandscapeRight:
					case UIInterfaceOrientation.LandscapeLeft:
						{
							x = (applicationFrame.Height - size.Width) / 2f;
							y = (applicationFrame.Width - size.Height) / 2f - 17f;
							break;
						}
				}
				return new RectangleF (x, y, size.Width, size.Height);
			}
			public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
			{
				NullableDateTimeElement.MyViewController myViewController = new NullableDateTimeElement.MyViewController (this)
				{
					Autorotate = dvc.Autorotate
				};
				this.datePicker = this.CreatePicker ();
				this.datePicker.Frame = NullableDateTimeElement.PickerFrameWithSize (this.datePicker.SizeThatFits (SizeF.Empty));
				myViewController.View.BackgroundColor = UIColor.Black;
				myViewController.View.AddSubview (this.datePicker);
				dvc.ActivateController (myViewController);
			}
		}
	}
