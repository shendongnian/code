        public void OrderUp(int favouriteId)
        {
            ChangeOrder(false, favouriteId);
        }
        public void OrderDown(int favouriteId)
        {
            ChangeOrder(true, favouriteId);
        }
        private void ChangeOrder(bool OrderDown, int favouriteId)
        {           
            UsFavourite currentFav = db.UsFavourites.FirstOrDefault(m => m.FavouriteID == favouriteId);
            // Get favourite by current favourite's order + 1
            UsFavourite tempFav;
            if (OrderDown)
            {
                tempFav = db.UsFavourites.OrderBy(m => m.FavouriteOrder).FirstOrDefault(m => m.FavouriteOrder > (currentFav.FavouriteOrder));
            }
            else
            {
                tempFav = db.UsFavourites.OrderByDescending(m => m.FavouriteOrder).FirstOrDefault(m => m.FavouriteOrder < (currentFav.FavouriteOrder));
            }
            if (tempFav != null)
            {
                //update tempFav
                tempFav.FavouriteOrder = currentFav.FavouriteOrder;
                //update currentFav
                currentFav.FavouriteOrder = currentFav.FavouriteOrder + change;
                Save();
            }
        }
