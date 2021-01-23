    var dGeoLocationNorth = rawDataStore["GeoLoc_AC_154"]; // Raw data store is a custom implementation of a dict which is optimized
    Console.WriteLine(dGeoLocatioNorth.Value); // Output: 295
    Console.WriteLine(rawDataStore["GeoLoc_AC_154"].Value); // Output: 295
    dGeoLocationNorth.Value = 1337;
    Console.WriteLine(dGeoLocatioNorth.Value); // Output: 1337
    Console.WriteLine(rawDataStore["GeoLoc_AC_154"].Value); // Output: 1337
