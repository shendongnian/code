     if(e.Error == null)
         // HERE YOU'D WANT TO MANAGE A REQUEST EXCEPTION
         // (FOR EXAMPLE AN UNPREDICTABLE PROBLEM OF THE BING WEB SERVICE!)
         // e.Error is an Exception class
     else
     {
         // Get the first result received:
         var geoResult = (from r in e.Result.Results
                         orderby (int)r.Confidence ascending // USE THIS CLAUSE TO SORT THE RESULT BY CONFIDENCE, OTHERWISE REMOVE IT!
                         select r).FirstOrDefault();
         // DO I HAVE A VALID RESULT?
         if (geoResult != null)
         {
             // I DO HAVE A VALID RESULT FOR GEOCODING!!
             // Defined a new point location for storing my information:
             Location currentLocation = new Location();
             // Set the coordinates:
             currentLocation.Latitude = geoResult.Locations[0].Latitude;
             currentLocation.Longitude = geoResult.Locations[0].Longitude;
             // Your problem was here:
             callBack(currentLocation.Locations[0]);
             // ...NEXT SOME SAMPLE CODE...
             // Set the point on the Bing map with a certain level of zoom:
             GeoLocationMap.SetView(currentLocation, 10);
             // Set the location of the visual pin on the map!
             GeoLocationMapPushpin.Location = currentLocation;
         }
     }
