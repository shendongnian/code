    public class GeoCoordinates {
	  public decimal Latitude { get; set; }
	  public decimal Longitude { get; set; }
	  
	  public GeoCoordinates( string latLongPair ) {
		decimal lat, lng;
		var parts = latLongPair.Split( new[] { ',' } );
		if( decimal.TryParse( parts[0], out lat ) &&
		  decimal.TryParse( parts[1], out lng ) ) {
		  Latitude = lat;
		  Longitude = lng;
		} else {
		  // you could set some kind of "ParseFailed" or "Invalid" property here
		}
	  }
	}
