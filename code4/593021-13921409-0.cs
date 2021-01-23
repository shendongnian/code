        public void MyTest()
        {
            // that is list which will contain passed names
            var actualNames = new List<string>();
            // stub only saves passed Name property into list
            var workerStub = MockRepository.GenerateStub<IWorker>();
            workerStub
                .Stub(w => w.DoWork(Arg<MyObject>.Is.Anything))
                .Do((Action<MyObject>)(mo => actualNames.Add(mo.Name)));
            var myObject = new MyObject { Name = "PersonA" };
            var target = new MyWorker();
            target.DoWork(workerStub, myObject);
            // here we do assert that names list contains what is required
            Assert.That(actualNames, Is.EqualTo(new[] { "PersonA", "PersonB" }));
        }
