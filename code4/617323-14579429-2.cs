    public class DinnerOperation
    {
      private IDinnerRepository dr;
      public DinnerOperation( IDinnerRespository repository ) {
         this.dr = repository;
      }
      // insert
      public void InsertDinner()
      {
          Dinner dinner = dr.GetDinner(5);
          dr.Dinner.Add(dinner);
          dr.Save();
      }
      // delete
      public void DeleteDinner()
      {
          Dinner dinner = dr.GetDinner(5);
          dr.Dinner.Delete(dinner);
          dr.Save();
      }
    }
