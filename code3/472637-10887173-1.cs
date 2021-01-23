	 public ActionResult Browse2(string genre)
			{
				// retrieve Genre and its associated albums from the database
				var genreModel = mcloUtilities.GetAlbums(genre);
				 
				return View(genreModel );
			}
		   
		   
