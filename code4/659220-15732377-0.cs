	Parallel.ForEach(
		urls,
		new ParallelOptions { MaxDegreeOfParallelism = 3 },
		url =>
		{
			try
			{
				var request = WebRequest.Create( url );
				request.Timeout = 10000; // milliseconds
				var response = request.GetResponse();
				// handle response
			}
			catch ( WebException x )
			{
				// timeout or some other problem with the request
			}
			catch ( Exception x )
			{
				// make sure this Action doesn't ever let an exception
				// escape as that would stop the whole ForEach loop
			}
		}
	);
