    public class Person
            {
                private int Id { get; set; }
                private string Name { get; set; }
                private string LastName {get; set;}
                public string CustomName()
                {
                    return "Name:- " + Name + " and Id is:- " + Id + "last name:- " + LastName;
                }
            }
