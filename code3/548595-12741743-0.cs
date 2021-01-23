    public class LastDateTimePicker : DateTimePicker {
		public LastDateTimePicker() {
		}
		protected override void OnValueChanged(EventArgs eventargs) {
			base.OnValueChanged(eventargs);
			LastValue = Value;
		}
		public DateTime? LastValue { get; private set; }
	}
