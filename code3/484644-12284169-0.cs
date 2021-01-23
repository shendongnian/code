    public DataServiceQuery<ImageResult> Image(String Query, String Options, String Market, String Adult, Double? Latitude, Double? Longitude, String ImageFilters, int? top, int? skip ) {
            if ((Query == null)) {
                throw new System.ArgumentNullException("Query", "Query value cannot be null");
            }
            DataServiceQuery<ImageResult> query;
            query = base.CreateQuery<ImageResult>("Image");
            if ((Query != null)) {
                query = query.AddQueryOption("Query", string.Concat("\'", System.Uri.EscapeDataString(Query), "\'"));
            }
            if ((Options != null)) {
                query = query.AddQueryOption("Options", string.Concat("\'", System.Uri.EscapeDataString(Options), "\'"));
            }
            if ((Market != null)) {
                query = query.AddQueryOption("Market", string.Concat("\'", System.Uri.EscapeDataString(Market), "\'"));
            }
            if ((Adult != null)) {
                query = query.AddQueryOption("Adult", string.Concat("\'", System.Uri.EscapeDataString(Adult), "\'"));
            }
            if (((Latitude != null) 
                        && (Latitude.HasValue == true))) {
                query = query.AddQueryOption("Latitude", Latitude.Value);
            }
            if (((Longitude != null) 
                        && (Longitude.HasValue == true))) {
                query = query.AddQueryOption("Longitude", Longitude.Value);
            }
            if ((ImageFilters != null)) {
                query = query.AddQueryOption("ImageFilters", string.Concat("\'", System.Uri.EscapeDataString(ImageFilters), "\'"));
            }
			if (((top != null)
						&& (top.HasValue == true)))
			{
				query = query.AddQueryOption("$top", top.Value);
			}
			if (((skip != null)
						&& (skip.HasValue == true)))
			{
				query = query.AddQueryOption("$skip", skip.Value);
			}
            return query;
        }
