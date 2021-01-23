    /// <summary>
	/// Other utility functions.
	/// </summary>
	public static class _ {
		/// <summary>
		/// Tries to execute the given action. If it fails, nothing happens.
		/// </summary>
		public static void Try(Action action) {
			try {
				action();
			}
			catch {
			}
		}
	}
