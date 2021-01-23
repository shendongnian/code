    public string GetNumberOfHotels()
    {
        var numberOfHotelCount = GetHotelsFromEan.GetListOfHotels();
        var root = JObject.Parse(numberOfHotelCount.ToString());
        IList<JToken> hotelCount = root["HotelListResponse"]["HotelList"].Children().ToList();
        IList<HotelCount> count = new List<HotelCount>();
        foreach (JToken hotel in hotelCount)
        {
            HotelCount countHotels = JsonConvert.DeserializeObject<HotelCount>(hotel.ToString());
            count.Add(countHotels);
        }
        var t = count.FirstOrDefault();
        return t.ActivePropertyCount;
    }
