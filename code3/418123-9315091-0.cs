            [TestMethod]
            public void TestMethod1()
            {
                Mapper.CreateMap<CreateContainerViewModel, Container>()
                    .ForMember(a => a.CurrentContainer, opt => opt.ResolveUsing<CustomResolver>());
    
    
                var source = new CreateContainerViewModel()
                {
                    ID = 3
                };
    
                var destination = new Container();
    
                Mapper.Map(source, destination);
    
                Assert.AreEqual(destination.CurrentContainer.ID, 3);
    
            }
