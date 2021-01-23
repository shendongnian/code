    public class RecordsController : ApiController
    {
        public HttpResponseMessage Post(Record record)
        {
            var newId = _Records.Count + 1;
            record.ID = newId;
            _Records.Add(record);
            var newMessage = new HttpResponseMessage<Record>(record);
            return newMessage;
        }
     }
