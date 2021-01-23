    public class PostData
    {
        public int ID { get; set; }
        public int[] SelectedChoiceIDs { get; set; }
    }
    public void DummyController : ApiController
    {
        public void Post(PostData data)
        {
            //data here will be PostData with ID and an array of 4 integers
        }
    }
