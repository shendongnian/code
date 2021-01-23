    void Deserialize(IRestResponse response)
    {
        string workingString = response.Content;
        var root = new JavaScriptSerializer().Deserialize<Root>(workingString);
        Vehicle[] list = root.Vehicles.Vehicle;
        // ... do something with the list of vehicles here
    }
