    public class Person: ICopyable<Person>
    {
        public string Name {set; get;}
        public int Age {set; get;}
        public void  CopyFrom(Person otherObject)
        {
 	        if (otherObject != null)
 	        {
                Name = otherObject.Name;
                Age = otherObject.Age;
 	        }
        }
        public Table1(int id)
        {
            using (DBDataContext item = new DBDataContext())
            {
                var q = (from c in item.table1
                     where c.ID == id
                     select c).FirstOrDefault() as Person;
                if (q != null)
                {
                    CopyFrom(q);
                }
            }
        }
    }
    public interface ICopyable<TType>
    {
        void CopyFrom(TType otherObject);
    }
