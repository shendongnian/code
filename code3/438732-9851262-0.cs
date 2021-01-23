     //call js to show the map with the markers
            string[] lats = new string[10];
            string[] longs = new string[10];
            for (int i = 0; i < 10; i++)
            {
                lats[i] = dv[i]["Latitude"].ToString();
            }
            for (int i = 0; i < 10; i++)
            {
                longs[i] = dv[i]["Longitude"].ToString();
            }
            string serializedLat = (new JavaScriptSerializer()).Serialize(lats);
            string serializedLong = (new JavaScriptSerializer()).Serialize(longs);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mapMarket", "buildMapWithMarkers('map_market', " + serializedLat + ", " + serializedLong + ", " + "false" + ");", true);
