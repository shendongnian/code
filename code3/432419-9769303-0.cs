		private List<Item> testAWS() {
			var s = new AWSECommerceServicePortTypeClient("AWSECommerceServicePortUK");
			s.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(AWSAccessKey, AWSSecureKeyID));
			var totalPages = 10; // Default value - changes on first iteration
			var books = new List<Item>();
			for(var i = 1; i < totalPages; i++) {
				var req = new ItemSearchRequest {
					SearchIndex = "Books",
					ItemPage = i.ToString(CultureInfo.InvariantCulture),
					Keywords = "Your ISBN", // There may be a better way to search for an ISBN - I haven't yet needed to
					Sort = "price", // Sort depends on which endpoint you are searching.
					Availability = ItemSearchRequestAvailability.Available, // Gets available products (mainly)
					ResponseGroup = new[] { "Small" } // Change for more details
				};
				var search = new ItemSearch {
					AWSAccessKeyId = AWSAccessKey,
					AssociateTag = AWSAssociateTag,
					Request = new[] { req }
				};
				var response = s.ItemSearch(search);
				// Store response in a list or something, which you can reorder as you want
				books.AddRange(response.Items[0].Item);
				totalPages = int.Parse(response.Items[0].TotalPages ?? "0");
			}
			// return your books, ordered by price ascending
			return books.OrderBy(b => b.Offers.Offer[0].OfferListing[0].Price.Amount).ToList();
		}
