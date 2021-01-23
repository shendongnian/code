	  public class clsUtilities
		{
			Utilities.MVCMusicStoreEntities db = new Utilities.MVCMusicStoreEntities();
			
			public IEnumerable<Utilities.vieAlbumArtist> GetAlbums(string GenreName)
			{
		 
			IEnumerable<vieAlbumArtist> query = from tags in db.vieAlbumArtists
						where tags.GenreName.Equals(GenreName)
						
						select tags;
				foreach (var n in query)
				{
					
				}
			return query;
			}
			
