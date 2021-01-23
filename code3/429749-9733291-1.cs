    public class Foo
    {
        private decimal _dbId;
        public decimal DbId 
        { 
            get { return _dbId; }
            set 
            { 
                _dbId = value;
                _id =(int)value;
            }
        }
        private String _dbCreadtedDate;
        public String DbCreadtedDate 
        { 
            get { return _dbCreadtedDate; }
            set 
            {
                _dbCreadtedDate = value;
                _createdDate = DateTime.Parse(_dbCreadtedDate);
            }
        }
        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; _dbId = value; } 
        }
        private DateTime _createdDate;
        public DateTime CreatedDate 
        { 
            get { return _createdDate; } 
            set { _createdDate = value; _dbCreadtedDate = value.ToString(); } 
        }
    }
