	public void Changed(string Key) {
		// Check if the property changed has subscribers.
		if (PropertyChanged != null) {
			// Invoke the property changed.
			PropertyChanged(this, new PropertyChangedEventArgs(Key));
		}
	}
