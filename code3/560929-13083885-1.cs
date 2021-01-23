    var users = new List&lt;User&gt;(){ /* Users here */}
    var mockedRepository = new Mock&lt;IRepository&gt;();
    
    //getup GET
    mockedRepository.Setup(
        self =&gt; self.Get&lt;User&gt;( It.IsAny&lt;int&gt;() )
    .Returns( (int id) => _users.First(u =&gt; u.Id == id) );
    
