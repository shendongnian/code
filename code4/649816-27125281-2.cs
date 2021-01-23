    class LogSaving : ISave
    {
        private readonly ILog logger;
        private readonly ISave next;
        public LogSaving(ILog logger, ISave next)
        {
            this.logger = logger;
            this.next = next;
        }
        public void Save<T>(T item) where T : IHasId
        {
            this.logger.Info(string.Format("Start saving {0} : {1}", item.ToJson()));
            next.Save(item);
            this.logger.Info(string.Format("Finished saving {0}", item.Id));
        }
    }
    class PublishChanges : ISave, IDelete
    {
        private readonly IPublish publisher;
        private readonly ISave nextSave;
        private readonly IDelete nextDelete;
        private readonly IGetById getter;
        public PublishChanges(IPublish publisher, ISave nextSave, IDelete nextDelete, IGetById getter)
        {
            this.publisher = publisher;
            this.nextSave = nextSave;
            this.nextDelete = nextDelete;
            this.getter = getter;
        }
        public void Save<T>(T item) where T : IHasId
        {
            nextSave.Save(item);
            publisher.PublishSave(item);
        }
        public void Delete<T>(object id)
        {
            var item = getter.GetById<T>(id);
            nextDelete.Delete<T>(id);
            publisher.PublishDelete(item);
        }
    }
