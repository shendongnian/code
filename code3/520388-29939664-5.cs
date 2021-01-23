    using Moq;
    var sqlException = 
    	new SqlExceptionBuilder().WithErrorNumber(50000)
    		.WithErrorMessage("Database exception occured...")
    		.Build();
    var repoStub = new Mock<IRepository<Product>>(); // Or whatever...
    repoStub.Setup(stub => stub.GetById(1))
    	.Throws(sqlException);
