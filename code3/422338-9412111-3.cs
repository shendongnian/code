        public void UdpateCoordinates<T>(IEnumerable<T> table, int ID, float latitude, float longitude ) where T: IPosition {
           var entity = table.Where(x.ID == ID).FirstOrDefault();
           if (entity != null){
               entity.Latitude = longitude ;
               entity.Longitude = longitude ;
           } 
    
           //Save the entity here
        }
