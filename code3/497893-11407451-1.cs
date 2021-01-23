    var resourceRepo = MockRepository.GenerateMock<IResourceRepository>();
    resourceRepo
      .Expect(r => r.GetById(
        Arg<int>.Is.Equal(123),
        Arg<string[]>.List.ContainsAll(new[]
                                       {
                                           "Name",
                                           "Super",
                                           "Mario",
                                           "No",
                                           "Yes",
                                           "Maybe"
                                       })))
      .Return(String.Empty);
