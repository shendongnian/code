    public void SaveContextChanges(MyEntityDataModelEDM.Payment paymentEntity)
    {
        using (var myObjectContext = new MyEntityDataModelEDM.LibraryReservationSystemEntities(connectionStringVal))
        {
            // use your own logic for determining a "new" entity
            myObjectContext.Entry(paymentEntity).State = 
                    (paymentEntity.PaymentID == default(int)) ?  
                                   EntityState.Added :
                                   EntityState.Modified;
            myObjectContext.SaveChanges();
        }
    }
