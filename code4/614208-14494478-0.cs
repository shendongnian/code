    IEnumerable<ImageGalleryCollection> GetImageGalleryCollection()
    {    
    
            SqlConnection connection = Dal.GetConnection();
            SqlParameter[] paramList = new SqlParameter[1];
            paramList[0] = new SqlParameter("@cityId", cityId);
            SqlDataReader data = Dal.ExecuteReaderSP(SPNames.GetRegCity, paramList,connection);
            while(data.Read())
            {
               ImageGalleryCollection igc = new ImageGalleryCollection1();
        
               igc.cityPhotoGalleryId = Convert.ToInt32(data["cityPhotoGalleryId"]);     
                igc.ImagePath = data["imagePath"].ToString();
                yield return igc;
        
            }
            data.Close();
            connection.Close();
    }
