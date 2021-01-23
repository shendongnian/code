	try {
		try {
			if(!Monitor.TryEnter(obj, 2000)) {
				throw new Exception("can not lock");
			}
		}
		finally {
			if(Monitor.TryEnter(obj, 0)) {
				Monitor.Exit(obj);
				Monitor.Exit(obj);
			}
		}
	}
	catch {
		//Log
	}
