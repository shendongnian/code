    fixture.Customize<User>(c => c.Without(x => x.Status));
    fixture.Customize<IEnumerable<User>>(
        c =>
        c.FromFactory(
            () => Enum.GetValues(typeof(Status)).Cast<Status>()
                      .Select(s => users.First(u => u.Status == s))));
    fixture.Create<IEnumerable<User>>(); // returns two Users
