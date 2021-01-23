            Person p = new Person();
            p.Name = "Sean Cocteau";
            p.Age = 99;
            DataContractSerializer ds = new DataContractSerializer(p.GetType());
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ds.WriteObject(ms, p);                
                // Spit out
                Console.WriteLine("Output: " + System.Text.Encoding.UTF8.GetString(ms.ToArray()));
                Console.WriteLine("Message length: " + ms.Length.ToString());
            }
            
            Console.ReadKey();
