    internal class Program
    {
        private static void Main(string[] args)
        {
            //The below code is just me pulling some data out of the air to work with
            var listOfIds = new List<ObjectA>();
            var data = new List<ObjectB>();
            for (var i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    listOfIds.Add(new ObjectA(i));
                }
                data.Add(new ObjectB(i, DateTime.Now.AddDays(i)));
            }
            //Now we have two ILists which match the type of data you were talking about, and you simply query them like so
            var datesWhereIdIsInList = (from id in listOfIds
                                        from date in data
                                        where id.Id == date.Id
                                        select date).OrderByDescending(x => x.DateTime).ToList();
        }
        private class ObjectA
        {
            private readonly int _id;
            public ObjectA(int id)
            {
                _id = id;
            }
            public int Id
            {
                get { return _id; }
            }
        }
        private class ObjectB
        {
            private readonly int _id;
            private readonly DateTime _dateTime;
            public ObjectB(int id, DateTime dateTime)
            {
                _id = id;
                _dateTime = dateTime;
            }
            public int Id
            {
                get { return _id; }
            }
            public DateTime DateTime
            {
                get { return _dateTime; }
            }
        }
    }
