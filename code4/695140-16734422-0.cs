    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq.Dynamic;
    namespace LinqTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                person me = new person();
                me.FirstName = "Andy";
                me.Realtionships = new List<relationship>();
            
                person aunt = new person();
                aunt.FirstName = "Lucy";
                relationship rAunt = new relationship();
                rAunt.IsHappy = true;
                rAunt.Type = "Aunt";
                rAunt.Person = aunt;
                me.Realtionships.Add(rAunt);
                person uncle = new person();
                uncle.FirstName = "Bob";
                relationship rUncle = new relationship();
                rUncle.IsHappy = false;
                rUncle.Type = "Uncle";
                rUncle.Person = uncle;
                me.Realtionships.Add(rUncle);
                //string zQuery = args[0];
                var res = me.Realtionships.AsQueryable().Where("Type == \"Uncle\"");
                foreach (relationship item in res)
	            {
        		    Console.WriteLine(item.Person.FirstName); 
	            }
                
                Console.ReadLine();
           
            }
        }
        public class person
        {
            private string _firstName;
            public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }
            private string _lastName;
            public string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }
            private List<relationship> _realtionships;
            public List<relationship> Realtionships 
            {
                get { return _realtionships; }
                set { _realtionships = value; }
            }
        
        }
        public class relationship : IEnumerable<relationship> 
        {
            private string _type;
            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }
            private bool _isHappy;
            public bool IsHappy
            {
                get { return _isHappy; }
                set { _isHappy = value; }
            }
            private person _person;
            public person Person
            {
                get { return _person; }
                set { _person = value; }
            }
            public IEnumerator<relationship> GetEnumerator()
            {
                throw new NotImplementedException();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
