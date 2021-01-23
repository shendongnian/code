    public string GetNumberOfHotels()
    {      
        var numberOfHotelCount = GetHotelsFromEan.GetListOfHotels();
        var root = JObject.Parse(numberOfHotelCount.ToString());
        // Get list of hotels
        IList<JToken> hotels = root["HotelListResponse"]["HotelList"].Children().ToList()
            .Select(hotel => JsonConvert.DeserializeObject<HotelCount>(hotel.ToString())).ToList();
        // Now get ActivePropertyCount for each hotel
        int totalCount = 0;
        foreach (JToken jToken in hotels)
        {
            totalCount += jToken.Value<int>("ActivePropertyCount");
        }
        return totalCount.ToString();
    }
