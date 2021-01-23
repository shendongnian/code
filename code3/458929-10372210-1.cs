        public void BuildData()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            
            RatingKC Ratings = new RatingKC();
            const Int16 NoOfUsers = 1000;
            const Int16 NoOfRatingsPerUser = 1000;
            const Int16 NoOfDifferentItems = 1000;
            Int16 itemID;
            int score;
            Int32 key;
            var r = new Random();
            
            for (Int16 userID = 0; userID < NoOfUsers; userID++)
            {
                for (int ratingsPerUser = 0; ratingsPerUser < NoOfRatingsPerUser; ratingsPerUser++)
                {
                    itemID = (Int16)r.Next(1, NoOfDifferentItems);
                    score = r.Next(1, 10);
                    key = (userID & 0xffff) + (itemID << 16);
                    if (Ratings.Contains(key))
                    {
                        Ratings[key].Score = score;
                    }
                    else
                    {
                        Ratings.Add(new Rating(userID, itemID, score));   
                    }
                }
            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            System.Diagnostics.Debug.WriteLine("Count = " + Ratings.Count.ToString() + " Time = " + elapsedTime);
        }
    }
    public class RatingKC : KeyedCollection<int, Rating>
    {
        // The parameterless constructor of the base class creates a 
        // KeyedCollection with an internal dictionary. For this code 
        // example, no other constructors are exposed.
        //
        public RatingKC() : base() { }
        // This is the only method that absolutely must be overridden,
        // because without it the KeyedCollection cannot extract the
        // keys from the items. The input parameter type is the 
        // second generic type argument, in this case OrderItem, and 
        // the return value type is the first generic type argument,
        // in this case int.
        //
        protected override int GetKeyForItem(Rating item)
        {
            // In this example, the key is the part number.
            return item.Key;
        }
    }
    public class Rating: Object
    {
        public Int16 UserId { get; private set; }
        public Int16 ItemId { get; private set;}
        public int Score { get; set;}
        public Int32 Key { get { return (UserId & 0xffff) + (ItemId << 16); } }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !(obj is Rating)) return false;
            Rating item = (Rating)obj;
            return (UserId == item.UserId && ItemId == item.ItemId);
        }
        public override int GetHashCode()
        {
            return Key;
        }
        public Rating(Int16 userId, Int16 itemId, int score)
        { UserId = userId; ItemId = itemId; Score = score; }
        public Rating(Int16 userId, Int16 itemId)
        { UserId = userId; ItemId = itemId; }
    }   
