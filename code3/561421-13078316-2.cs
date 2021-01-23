    public class MyClient{
        IRepository _repository;
        public MyClient(IRepository repository)
        {
            _repository = repository;
        }
        public void Main(){
             AuditInfo entity = new AuditInfo();
             //do whatever you want
             _repository.Save();
        }
    }
