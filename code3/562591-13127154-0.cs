                    double longitude=0;
                    double latitude=0;
                    var city = from c in db.Cities
                               where c.Code == Convert.ToInt32(Request.QueryString["Area"])
                               select c;
                    city = city.Take(1);//take the first value, that sould be the only value in this case
                    if (city.Count() == 0)
                    {
                        //hanlde error
                    }
                    else
                    {
                        City cit  = city.First();
                        Calculations.GetLongitudeLatitudeGoogle getLongLat = new Calculations.GetLongitudeLatitudeGoogle();
                        getLongLat.GetLongitudeLatitude("", cit.Name, "", out longitude, out latitude);
                    }
                    
                    var doctorPractise = from d in db.DoctorsPrivateClinics.AsEnumerable()//or .ToList()
                                         where CalcualateDistance(Convert.ToDouble(d.PrivateClinic.Latitude), Convert.ToDouble(d.PrivateClinic.Longtitude), latitude, longitude)<5.0f
                                                              
                                         select d;
