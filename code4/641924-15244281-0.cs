            string SimilarCharacters = "l!1iO0oI";
			var listOfSimilarCharacters = new Dictionary<string, string>();
			bool timeToAdd = false;
			string key = String.Empty;
			string value = String.Empty;
			foreach ( var c in SimilarCharacters )
			{
				if ( timeToAdd )
				{
					value = c.ToString();
					listOfSimilarCharacters.Add( key, value );
				}
				else
				{
					key = c.ToString();
				}
				timeToAdd = !timeToAdd;
			}
