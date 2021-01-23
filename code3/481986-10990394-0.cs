    var amenities = unitSearchRequest.Amenities;
    if (amenities.Count > 0)
    {
        //filter the unit's amenities's id's with the search request amenities's ID's.
        var exactMatchApartmentsFilteredByAmenities= new Units();
        var requestAmenitiesIds = amenities.Select(element => element.ID);
        foreach (var unitCounter in ExactMatchApartments)
        {
            var unitAmenities = unitCounter.Amenities.Select(element => element.ID);
            var intersect    =unitAmenities.Intersect(requestAmenitiesIds);
            if (intersect.Any())
            {
                exactMatchApartmentsFilteredByAmenities.Add(unitCounter);
                break;
            }
        }
    }    
