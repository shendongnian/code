	public class TimedGroup {
		TimedThing[] things;
		System.Timers.Timer timer;
		
		public TimedGroup() {
			this.timer = new System.Timers.Timer();
			this.timer.AutoReset = false;
			this.timer.Elapsed += TimerFired;
		}
		// some methods for adding and removing TimerThings
		public void Start() {
			this.timer.Interval = 1; // just to get things started
			this.timer.Enabled = true;
		}
		public void Stop() {
			this.timer.Enabled = false;
		}
		private void TimerFired(object sender, System.Timers.ElapsedEventArgs e) {
			DateTime now = DateTime.Now;
			DateTime next = now.AddMinutes(5); // at the least, we'll check every 5 minutes
			foreach(var thing in this.things) {
				if (thing.nextFiring <= now) {
					var task = Task.Factory.StartNew(() => DoWork(thing));
					thing.NextFiring = thing.NextFiring.AddSeconds(thing.IntervalSeconds);
					// or maybe this is more appropriate
					// thing.NextFiring = Now.AddSeconds(thing.IntervalSecs);
				}
				if (thing.NextFiring < next) next = thing.NextFiring;
			}
			this.Timer.Interval = (next - now).TotalMilliseconds;
			this.Timer.Enabled = true;
		}
		private void DoWork(TimedThing thing) {
			thing.Work();
		}
	}
