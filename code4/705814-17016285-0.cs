<br />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hostlib
{
    public class Person
    {
        public string Birthday;
        public string Name;
        public Person(string bday, string name)
        {
            Birthday = bday;
            Name = name;
        }
    }
}
