        [Fact]
        public void SuccessFullyRegisterGetAndSetEvents()
        {
            ProxyGenerator generator = new ProxyGenerator();
            var tracked = generator.CreateClassProxy<TrackedClass>(new GetSetInterceptor());
            tracked.SomeContent = "some content";
            Assert.Single(tracked.GetEvents());
            var eventAfterSomeContentAssigned = tracked.GetEvents().Last();
            Assert.Equal(EventType.Set, eventAfterSomeContentAssigned.EventType);
            Assert.Equal("some content", eventAfterSomeContentAssigned.Value);
            Assert.Equal("SomeContent", eventAfterSomeContentAssigned.PropertyInfo.Name);
            tracked.SomeInt = 1;
            Assert.Equal(2, tracked.GetEvents().Count);
            var eventAfterSomeIntAssigned = tracked.GetEvents().Last();
            Assert.Equal(EventType.Set, eventAfterSomeContentAssigned.EventType);
            Assert.Equal(1, eventAfterSomeIntAssigned.Value);
            Assert.Equal("SomeInt", eventAfterSomeIntAssigned.PropertyInfo.Name);
            var x = tracked.SomeInt;
            Assert.Equal(3, tracked.GetEvents().Count);
            var eventAfterSomeIntAccessed = tracked.GetEvents().Last();
            Assert.Equal(EventType.Get, eventAfterSomeIntAccessed.EventType);
            Assert.Equal(1, eventAfterSomeIntAccessed.Value);
            Assert.Equal("SomeInt", eventAfterSomeIntAccessed.PropertyInfo.Name);
        }
