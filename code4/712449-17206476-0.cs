     public dynamic  GetEntertainmentDetails(int entertainmentId)
        {
            dynamic result = (from PE in entities.ProductEntertainments
                         join PM in entities.ProductModels on PE.ProductModelID equals PM.ProductModelID
                         join PMA in entities.ProductMasters on PM.ProductUID equals PMA.ProductUID
                         join PMF in entities.ProductManufactorers on PMA.ManufactorerID equals PMF.ManufactorerID
                         where PE.EntertainmentID == entertainmentId
                         select new 
                         { 
                             PE.EntertainmentID, 
                             PMF.ManufactorerID, 
                             PMA.ProductUID, 
                             PM.ProductModelID, 
                             PE.CDPlayer, 
                             PE.CDChanger, 
                             PE.DVDPlayer, 
                             PE.Radio, 
                             PE.AudioSystemRemoteControl, 
                             PE.SpeakersFront, 
                             PE.SpeakersRear 
                         }).SingleOrDefault();
            return result;
        }
