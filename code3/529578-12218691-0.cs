	public EnquiryOrderMapping()
    {
        Id(x => x.Id).Column("EnquiryOrderId");
        Map(x => x.DateOrdered);
        Map(x => x.PONumber).Nullable();
        Map(x => x.SONumber).Nullable();
		Component(x => x.BuyerRatings,
			y => 
				{
					y.Map(r => r.RatingCriteria1, "EnquiryBuyerRatingsRatingCriteria1").Nullable();
					y.Map(r => r.RatingCriteria2, "EnquiryBuyerRatingsRatingCriteria2").Nullable();
					y.Map(r => r.RatingCriteria3, "EnquiryBuyerRatingsRatingCriteria3").Nullable();
					// etc..
				});		
		// etc..
    }
