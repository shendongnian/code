	bool bIsSingleInstance;
	using (new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out bIsSingleInstance)) {
		if (bIsSingleInstance) {
			// START APP HERE.
		}
	}
