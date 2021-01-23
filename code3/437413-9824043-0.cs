     public class NhibernateEventListeners :  IPreInsertEventListener
        {
             public bool OnPreInsert(PreInsertEvent nHibernateEvent)
            {
                var entityBeingInserted = nHibernateEvent.Entity;
                if (entityBeingInserted == null)
                    return false;
                 if (property.PropertyType==typeof(string))
                     {
                        //use reflection to set the property value to null   
                     }
                return false;
            }
       }
