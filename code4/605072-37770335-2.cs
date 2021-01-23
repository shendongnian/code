	[TestMethod]
	public void TestMethod()
	{
		var user = new User() { Name = "John", Age = 42 };
		var vehicle = new Vehicle {FleetNumber = 36, Registration = "XYZ123"};
		var configuration1 = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<CommonProfile>();
			cfg.AddProfile<Profile1>();
		});
		var mapper1 = configuration1.CreateMapper();
		var mappedUser1 = mapper1.Map<User, User>(user);//maps both Name and Age
		var mappedVehicle1 = mapper1.Map<Vehicle, Vehicle>(vehicle);//Maps both FleetNumber 
                                                                    //and Registration.
		var configuration2 = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<CommonProfile>();
			cfg.AddProfile<Profile2>();
		});
		var mapper2 = configuration2.CreateMapper();
		var mappedUser = mapper2.Map<User, User>(user);//maps only Name
		var mappedVehicle2 = mapper2.Map<Vehicle, Vehicle>(vehicle);//Same as mappedVehicle1.
	}
