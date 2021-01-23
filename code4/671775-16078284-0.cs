	class MyClassName {
		private static DateTime _currentPollStartDate=DateTime.MinValue; //As Default
		private static DateTime _currentPollEndDate=DateTime.MinValue; //As Default
		public void ProcessItems() {
			var Items=GetItems();
			//In here, it reaches inside
			if(Items.HasItems) {
				//Items[0].PollStartDate.HasValue is TRUE
				//I can NOT set either Items[0].PollStartDate.Value or DateTime.MaxValue
				_currentPollStartDate=Items[0].PollStartDate.HasValue?Items[0].PollStartDate.Value:DateTime.MaxValue;
				//Items[0].PollEndDate.HasValue is TRUE
				//I can NOT set either Items[0].PollEndDate.Value or DateTime.MaxValue
				_currentPollEndDate=Items[0].PollEndDate.HasValue?Items[0].PollEndDate.Value:DateTime.MaxValue;
			}
			//...
		}
		public void _ProcessItems() {
			var Items=GetItems();
			//In here, it reaches inside
			if(Items.HasItems) {
				if(Items[0].PollStartDate.HasValue)
					_currentPollStartDate=Items[0].PollStartDate.Value;
				if(Items[0].PollEndDate.HasValue)
					_currentPollEndDate=Items[0].PollEndDate.Value;
			}
			//...
		}
		Items GetItems() {
			return new Items();
		}
	}
	class Items: List<Item> {
		public bool HasItems {
			get;
			set;
		}
	}
	class Item {
		public DateTime? PollStartDate {
			get;
			set;
		}
		public DateTime? PollEndDate {
			get;
			set;
		}
	}
