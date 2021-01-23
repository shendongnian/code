     public class LocatieManagement : DataContext
     {
            public static void addLocatie(locatie nieuweLocatie)
            {
                dc.locaties.InsertOnSubmit(nieuweLocatie);
                dc.SubmitChanges();
            }
     }
