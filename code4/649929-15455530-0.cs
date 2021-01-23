    [TestFixture]
    public class WorkerThing
    {
        [Test]
        public void RegisterAndRetrieveWorkers()
        {
            var repo = new WorkerRepository();
            repo.RegisterWorker(new WorkerA());
            var workerA = repo.RetrieveWorkerForWorkItem(new WorkItemA());
            Assert.IsTrue(workerA is WorkerA);
            
            repo.RegisterWorker(new WorkerB());
            var workerB = repo.RetrieveWorkerForWorkItem(new WorkItemB());
            Assert.IsTrue(workerB is WorkerB);
        }
    }
