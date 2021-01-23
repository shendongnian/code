        public void BuildData()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            
            HashSet<Rating> Ratings = new HashSet<Rating>();
            const int NoOfUsers = 100;
            const int NoOfRatingsPerUser = 100;
            const int NoOfDifferentItems = 100;
            int itemID;
            int score;
            Rating existingRating;
            Rating srchRating;
            var r = new Random();
            
            for (int userID = 0; userID < NoOfUsers; userID++)
            {
                for (int ratingsPerUser = 0; ratingsPerUser < NoOfRatingsPerUser; ratingsPerUser++)
                {
                    itemID = r.Next(1, NoOfDifferentItems);
                    score = r.Next(1, 10);
                    existingRating = Ratings.FirstOrDefault(x => x.UserId == userID && x.ItemId == itemID);
                    if(existingRating == null)
                    {
                        Ratings.Add(new Rating(userID, itemID, score));   
                    }
                    else
                    {
                        existingRating.Score = score;
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
    public class Rating: Object
    {
        public int UserId { get; private set; }
        public int ItemId { get; private set;}
        public int Score { get; set;}
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !(obj is Rating)) return false;
            Rating item = (Rating)obj;
            return (UserId == item.UserId && ItemId == item.ItemId);
        }
        public override int GetHashCode()
        {
            return (int)UserId;
        }
        
        public Rating (int userId, int itemId, int score)
        { UserId = userId; ItemId = itemId; Score = score; }
        public Rating(int userId, int itemId)
        { UserId = userId; ItemId = itemId; }
    }   
