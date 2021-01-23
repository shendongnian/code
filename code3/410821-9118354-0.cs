    public static object[] GetSubsystems()
    {
        Subsystem[] subsystems = new Subsystem[]
                                     {
                                         new Subsystem() {Id=1, Name = "A"},
                                         new Subsystem() {Id=2, Name = "B"},
                                         new Subsystem() {Id=3, Name = "C"}
                                     };
       object[] anonymousSubsystems = (from subsystem in subsystems
                                       select (object)(new { Id = subsystem.Id, Name = subsystem.Name })).ToArray();
		return anonymousSubsystems;
	}
