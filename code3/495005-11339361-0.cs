        [Test]
        public void Foo()
        {
            var list = new List<string>();
            var watcher = new FakeIFileSystemWatcher();
            watcher.FilesToBeImported
                .ObserveOnDispatcher()
                .Subscribe(list.Add);
            Task task = Task.Factory.StartNew(() =>
            {
                watcher.AddFile("cc");
                watcher.AddFile("cc");
                watcher.AddFile("cc");
                watcher.AddFile("cc");
            }, TaskCreationOptions.LongRunning);
            Task.WaitAll(task);
            DispatcherUtil.DoEvents();
            Assert.AreEqual(4, list.Count);
        }
