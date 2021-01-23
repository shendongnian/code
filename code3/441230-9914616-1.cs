        [WebMethod]
        public object GetPOIMarkersFrontendByTypeAndZip(string latlng, string type, string distance)
        {
            var db = new SQLConnectionDataContext();
            string[] zip = latlng.Split(',');
            IQueryable<POI> points = db.POIs;
            int dist = string.IsNullOrEmpty(distance) ? 0 : Convert.ToInt32(distance);
            List<POI> poi = type == "0"
                                ? points.ToList()
                                : points.Where(p => p.poiTypeId == Convert.ToInt32(type)).ToList();
            return (from item in poi
                    where !string.IsNullOrEmpty(item.Lat) && !string.IsNullOrEmpty(item.Lng)
                    let dDist =
                        DoCalc(Convert.ToDouble(zip[0]), Convert.ToDouble(item.Lat.Trim()), Convert.ToDouble(zip[1]),
                               Convert.ToDouble(item.Lng.Trim()))
                    where dDist <= dist
                    select new GoogleMapMarker
                               {
                                   lat = item.Lat,
                                   lng = item.Lng,
                                   data = FpsFunctions.IsLanguageFrench() ? item.fr : item.gb,
                                   tag = item.poiTypeId.ToString()
                               }).ToList();
        }
