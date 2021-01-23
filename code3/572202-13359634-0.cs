    class MonkeyItemizedOverlay: ItemizedOverlay
    {
       List<OverlayItem> _items;
                     
       public MonkeyItemizedOverlay (Drawable monkey) : base(monkey)
       {     
              // populate some sample location data for the overlay items
              _items = new List<OverlayItem>{
                      new OverlayItem (new GeoPoint ((int)40.741773E6,
                             (int)-74.004986E6), null, null),
                      new OverlayItem (new GeoPoint ((int)41.051696E6,
                             (int)-73.545667E6), null, null),
                      new OverlayItem (new GeoPoint ((int)41.311197E6,
                             (int)-72.902646E6), null, null)
              };
                            
              BoundCenterBottom(monkey);
              Populate();
       }
    }
