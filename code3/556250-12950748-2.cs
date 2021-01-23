    public class YourModel
    {
        public YourModel(User createdBy)
        {
            CreatedDate = DateTime.Now;
            CreatedBy = createdby;
        }
     
        // for persistance
        protected YourModel()
        {}
    }
