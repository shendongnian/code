        static void Main(string[] args)
        {
            Person person = new Person { Address = new Address { PostCode = new Postcode { Value = "" } } };
            if (NullHelper.ChainNotNull(person, p => p.Address, a => a.PostCode, p => p.Value))
            {
                Console.WriteLine("Not null");
            }
            else
            {
                Console.WriteLine("null");
            }
            Console.ReadLine();
        }
