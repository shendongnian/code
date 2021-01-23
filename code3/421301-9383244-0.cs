            // Grab pre-built session variable with comma delimited int values
			string RecentClients = Session["RecentClients"].ToString();
			
			// Convert to Array
			int[] RecentClientsArray = Array.ConvertAll(RecentClients.Split(','), n => Convert.ToInt32(n));
			
			
			//NEW- I use dictionary to get the right place in reverse
			int ind = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in RecentClientsArray.Reverse())
            {
                dic.Add(item, ind);
                ind++;
            }
			
			
			// Display in gridview to see current order of array (For debug purposes)
			gridArray.DataSource = RecentClientsArray;
			gridArray.DataBind();
			
			// Setup LINQ
			DataClasses1DataContext db = new DataClasses1DataContext();
			
			// Populate RecenClientList using RecentClientsArray to compare to ConsumerID
			//NEW- use orderby with dictionary
			var RecentClientList = (from c in db.ClientNames
			where RecentClientsArray.Contains(c.ConsumerID)
			orderby dic[c.ConsumerID]
			select new { FullName = c.LastName + ", " + c.FirstName + " #" + c.ConsumerID, recentConsumerID = c.HorizonID, ID = c.ConsumerID });
			
			// Display in gridview to see new order after populating var RecentClientList (for debug purposes)
			gridList.DataSource = RecentClientList;
			gridList.DataBind();
			
			// Set and bind values for dropdown list.
			ddLastClients.DataSource = RecentClientList;
			ddLastClients.DataTextField = "FullName";
			ddLastClients.DataValueField = "recentConsumerID";
			ddLastClients.DataBind();			
