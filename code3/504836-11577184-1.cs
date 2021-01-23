            var list1 = new List<Email>();
            var ran = new Random();
            for (int i = 0; i < 50; i++)
            {
                list1.Add(new Email() { Body = "Body " + i, Subject = "Subject " + i, UserName = "username " + i, TimeStamp = DateTime.UtcNow.AddMinutes(ran.Next(-360, 60)) });
            }
            var list2 =  new List<Email>();
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                    list2.Add(new Email() { Body = "Body " + i, Subject = "Subject Modifed" + i, UserName = "username " + i, TimeStamp = DateTime.UtcNow.AddMinutes(ran.Next(-360, 60)) });
                else 
                    list2.Add(new Email() { Body = "Body " + i, Subject = "Subject " + i, UserName = "username " + i, TimeStamp = DateTime.UtcNow.AddMinutes(ran.Next(-360, 60)) });
            }
            foreach (var item in list2.Intersect<Email>(list1))
            {
                Console.WriteLine(item);
            }
            foreach (var item in list1)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    if (list2[i].Equals(item))
                    {
                        Console.WriteLine(item);
                        list2.RemoveAt(i);
                        break;
                    }
                }
            }
            Console.WriteLine(list2.Count);
