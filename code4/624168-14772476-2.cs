    public List<BLL.Entities.DataManagement_Hotels_Amenities_AmenityValidDatesPrice> SelectByAmenityID(int ID)
    {
    	DAL.DynamicSearchViewDataContext Viewcontext = new DAL.DynamicSearchViewDataContext();
    	DAL.SelectSectionDataContext SpContext = new DAL.SelectSectionDataContext();
    	var Query = (from car in Viewcontext.View_DataManagement_Hotel_Amenities_Dates
    				 where car.AmenityID.Equals(ID)
    				 select new BLL.Entities.DataManagement_Hotels_Amenities_AmenityValidDatesPrice
    				 {
    					 AmenityID = (int)car.AmenityID,
    					 if (car.AmenityValidDatesFrom != null && car.AmenityValidDatesFrom.ToString() !=  "")
    					 {
    						AmenityValidDatesFrom = car.AmenityValidDatesFrom.Date
    					 },
    					 if (car.AmenityValidDatesTo != null && car.AmenityValidDatesTo.ToString() !=  "")
    					 {
    						AmenityValidDatesTo = car.AmenityValidDatesTo.Date
    					 }
    				 }).ToList<BLL.Entities.DataManagement_Hotels_Amenities_AmenityValidDatesPrice>();
    	return Query;
    }
