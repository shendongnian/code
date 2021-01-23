    public class LastDateTimePicker : DateTimePicker {
		protected override void OnValueChanged(EventArgs eventargs) {
			base.OnValueChanged(eventargs);
			LastValue = Value;
			IsProgrammaticChange = false;
		}
		public DateTime? LastValue { get; private set; }
		public bool IsProgrammaticChange { get; private set; }
		public new DateTime Value { 
			get { return base.Value; }
			set {
				IsProgrammaticChange = true;
				base.Value = value;
			}
		}
	}
