	using System;
	using MonoTouch.Foundation;
	using MonoTouch.UIKit;
	namespace MonoTouch.Dialog
	{
		public class NullableDateElement : NullableDateTimeElement
		{
			public NullableDateElement (string caption, DateTime? date, string nullButtonCaption, string setButtonCaption) : base (caption, date, nullButtonCaption, setButtonCaption)
			{
				initDateOnlyPicker ();
			}
			
			public NullableDateElement (string caption, DateTime? date, string nullButtonCaption) : base(caption, date, nullButtonCaption)
			{
				initDateOnlyPicker ();
			}
			
			public NullableDateElement (string caption, DateTime? date) : base(caption, date)
			{
				initDateOnlyPicker ();
			}
			
			
			void initDateOnlyPicker()
			{
				this.fmt.DateStyle = NSDateFormatterStyle.Medium;
			}
			
			public override string FormatDate (DateTime? dt)
			{
				if (dt.HasValue)
					return this.fmt.ToString (dt);
				else
					return base.NullButtonCaption;
			}
			public override UIDatePicker CreatePicker ()
			{
				UIDatePicker uIDatePicker = base.CreatePicker ();
				uIDatePicker.Mode = UIDatePickerMode.Date;
				return uIDatePicker;
			}
		}
	}
