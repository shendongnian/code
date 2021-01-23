    networkingEntities net=new networkingEntities(str);
    
    
    public List<utilizator> ListaUtilizatori()
            {
                
                var query = from u in net.utilizator
                            select u;
                List<utilizator> users = new List<utilizator>();
                try
                {
                    users = query.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return users;
            }
