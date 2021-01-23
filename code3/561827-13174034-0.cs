    public void Save(Car car)
    {
        using (DBContext context = new DBContext())
        {
            // No need to save if it already exists
            if ( context.Cars
                        .Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return;
            }
            else
            {
                //Assign scalar properties to the deep copy
                Car carToBeSaved = new Car 
                {
                    carToBeSaved.RegistrationNumber = car.RegistrationNumber,
                    carToBeSaved.Price = car.Price
                }
    
                
                //Car -> Trader -> ...
                if(car.Trader != null)
                {   
                    Trader existingTrader = 
                        context.Traders
                               .FirstOrDefault(x => x.Name == car.Trader.Name);
                    
                    //If exists in DB assign, if not deep copy
                    carToBeSaved.Trader = existingTrader ??
                        new Trader
                        {
                            Name = car.Trader.Name,
                            JobTitle = car.Trader.JobTitle
                        }
    
                    //Car -> Trader -> TraderCompany
                    if(car.Trader.TraderCompany != null)
                    {
                        TraderCompany existingTraderCompany = 
                            context.TradersCompanys
                                   .FirstOrDefault(x => x.Name == car.Trader
                                                                     .TraderCompany
                                                                     .Name);
    
                        //If exists in DB assign, if not deep copy  
                        carToBeSaved.Trader.TraderCompany = existingTraderCompany ??
                            new TraderCompany
                            {
                                Name = car.Trader.TraderCompany.Name,
                                Address = car.Trader.TraderCompany.Address,
                                PhoneNumber = car.Trader.TraderCompany.PhoneNumber
                            }
                    }
                }
                
                //Car -> Model -> ...
                if(car.Model != null)
                {   
                    Model existingModel = 
                        context.Models
                               .FirstOrDefault(x => x.Name == car.Model.Name);
                    
                    //If exists in DB assign, if not deep copy
                    carToBeSaved.Model = existingModel ??
                        new Model
                        {
                            Name = car.Model.Name
                        }
    
                    //Car -> Model -> Manufacturer
                    if(car.Model.Manufacturer != null)
                    {
                        Manufacturer existingManufacturer = 
                            context.Manufacturers
                                   .FirstOrDefault(x => x.Name == car.Model
                                                                     .Manufacturer
                                                                     .Name);
    
                        //If exists in DB assign, if not deep copy
                        carToBeSaved.Model.Manufacturer = existingManufacturer ??
                        new Manufacturer
                            {
                                Name = car.Model.Manufacturer.Name
                            }
                    }
                }
    
                //Mark the Car for Addition to the DB
                context.Cars.AddObject(car);
                context.SaveChanges();
    
            }
        }
    }
