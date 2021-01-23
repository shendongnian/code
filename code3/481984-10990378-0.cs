    var matchedAmenities = ExactMatchApartments.Where(ema => ema.Amenities
                                                   .Where(x => unitSearchRequestAmenities
                                                       .Count(y => y.ID == x.ID)
                                                    > 0));
    exactMatchApartmentsFilteredByAmenities.AddRange(matchedAmenities);
