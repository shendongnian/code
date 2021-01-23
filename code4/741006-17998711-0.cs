    public FileContentResult GetImage(int newcarid)
            {
                DBAppl db = new DBAppl();
                newcar car = (from p in db.newcars
                                  where p.newcarid == newcarid
                                   select p).First();
                return File(car.ImageData**.ToArray()**, car.mimetype.Trim());
            }
