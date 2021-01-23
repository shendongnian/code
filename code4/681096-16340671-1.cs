    public class HouseProperties {
        public string Colour { get; set; }
        public int NumFloors { get; set; }
        public int Year { get; set; }
    }
    // Create a Dictionary of House Sizes
    // Use a List<HouseProperties> so you can have multiple houses
    // of a house size, that can even have the same colour, number
    // of floors and/or year
    Dictionary<HouseSize, List<HouseProperties>> HouseDictionary = new Dictionary<HouseSize, List<HouseProperties>>();
    // Initialize the House sizes
    HouseDictionary.Add(HouseSize.Big, new List<HouseProperties>());
    HouseDictionary.Add(HouseSize.Medium, new List<HouseProperties>());
    HouseDictionary.Add(HouseSize.Small, new List<HouseProperties>());
    // Adding a 2013 one-floor Mahogany Big House to the Dictionary
    HouseDictionary[HouseSize.Big].Add(new HouseProperties() {
        Colour = "Mahogany",
        NumFloors = 1,
        Year = 2013
    });
