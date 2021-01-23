    class Locations : IDisposable { 
    	int PersonId;
    	int Latitude;
    	int Longitude;
    	int SentTimeUTC;
    	int ReceivedTimeLocal;
    	int CivicAddress;
    
    	// Functions;
    
    	// {
    	// Disposable resource
    	// }
    	public Locations (latitude,longitude,sentTimeUTC,receivedTimeLocal,civicAddress)
    	{
    		PersonId = personId;
    		Latitude = latitude;
    		Longitude = longitude;
    		SentTimeUTC = sentTimeUTC;
    		ReceivedTimeLocal = receivedTimeLocal;
    		CivicAddress = civicAddress;
    	}
    
    	public void Dispose() {
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposing) {
    		if (disposing) {
    			// Free your disposable resources here
    			base.Dispose(disposing);
    		}
    	}
    };
