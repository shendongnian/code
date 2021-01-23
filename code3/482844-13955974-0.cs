        [Fact]
        public void Test()
        {
            // Arange
            // Act
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { service.DoStuff(); }));
            // Assert
            Assert.IsType(typeof(<whatever exception type you are looking for>), ex);
            Assert.Equal("<whatever message text you are looking for>", ex.Message);
        }
