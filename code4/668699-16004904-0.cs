        [Fact]
        public void Verify_SelectSingle_IsCalledOnce( ){
            Guid id = Guid.Parse( "CB594050-3845-4EAF-ABC5-34840063E94F" );
            var cwMock = new Mock<ConsoleApplication1.IEntityUtil>( );
            var post = new ConsoleApplication1.Post{ Id = id };
            cwMock
              .Setup( x=> x.SelectSingle<ConsoleApplication1.Post>(It.IsAny<Guid> ))
              .Returns( post );
            var sut = new ConsoleApplication1.sut(cwMock.Object);
            sut.Search();
            cwMock.Verify( 
              x=> x.SelectSingle( It.IsAny<ObjectContect>( o => o.Id == id )), 
              Times.Once);
        }
