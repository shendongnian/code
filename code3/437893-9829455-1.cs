                List<Foo> newFoos = new List<Foo>();
                Foo selected = null;
                foreach (Foo foo in firstFoos)
                {
                    selected = secondFoos.FirstOrDefault(x => x.Id == foo.Id);
                    if (selected != null)
                    {                   
                        newFoos.Add(selected);                   
                    }
                    else
                    {
                        
                        newFoos.Add(foo);
                    } 
                }
