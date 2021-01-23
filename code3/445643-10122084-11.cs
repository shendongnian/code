	private void CheckForNewTasks()
	{
		MapCommand newCommand;
		while (_mapCommandQueue.TryDequeue(out newCommand))
		{
			switch (newCommand.Type)
			{
				case MapCommand.CommandType.AircraftLocation:
					SetAircraftLocation((LatLon)newCommand.Arguments[0]);
					break;
				default:
					Console.WriteLine(String.Format("Unknown command '0x{0}'for window", newCommand.Type));
					break;
			}
		}
	}
