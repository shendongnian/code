	void SetLocation(Point location) {
		var context=SynchronizationContext.Current;
		(new Thread(
			() => {
				SendOrPostCallback d=dummy => {
					this.Location=location;
				};
				for(; ; Thread.Sleep(0))
					try {
						context.Send(d, null);
					}
					catch(InvalidAsynchronousStateException ex) {
						break;
					}
			})).Start();
	}
