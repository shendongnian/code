    public string GetNumberOfHotels()
    {
        var numberOfHotelCount = GetHotelsFromEan.GetListOfHotels();
        var root = JObject.Parse(numberOfHotelCount.ToString());
        IList<JToken> hotels = root["HotelListResponse"]["HotelList"].Children().ToList();
        int count = hotels.Select(hotel => JsonConvert.DeserializeObject<HotelCount>(hotel.ToString())).ToList().Count();
        return count.ToString();
    }
