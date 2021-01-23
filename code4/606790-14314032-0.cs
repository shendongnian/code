   				DateTime currentTime = DateTime.Now;
				DateTime scheduledTime = dataReader.GetDateTime(0);
				TimeSpan timeDifference = scheduledTime - currentTime;
				if (timeDifference <= new TimeSpan(0, 15, 0)) //less 15m
				{
					Style.SelectionBackColor = Color.Red;
					ForeColor = Color.White;
				}
				else if (timeDifference <= new TimeSpan(0, 30, 0)) //15m - 30m
				{
					Style.SelectionBackColor = Color.Yellow;
					ForeColor = Color.Black;
				}
				else if (timeDifference <= new TimeSpan(2, 0, 0))//30m - 2hr
				{
					Style.SelectionBackColor = Color.Green;
					ForeColor = Color.White;
				}
				else // > 2hr
				{
					//:todo: create styles for time difference > 2 hr
				}
