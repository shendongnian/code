    [TestMethod]
    public void CreateMyTicketTest() 
    {
        // arrange
        var repositoryStub = MockRepository.GenerateStub<IRepository>();
        var sut = new ClassToTest(repositoryStub);
        var ticketNumber = 5;
        var name = "John";
        // act
        sut.CreateMyTicket(ticketNumber, name);
        
        // assert
        repositoryStub.AssertWasCalled(
            x => x.Save(
                Arg<TicketObject>.Matches(t => 
                    t.Upgrade == 7 && 
                    t.Name == name && 
                    t.TicketNumber == ticketNumber
                )
            )
        );
    }
