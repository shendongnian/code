                using (var dr = new DynamicRepo())
                {
                    dr.Add<House>(model.House);
                    foreach (var rs in model.Rooms)
                    {
                        rs.HouseId = model.House.HouseId;
                        dr.Add<Room>(rs);
                    }
                }
