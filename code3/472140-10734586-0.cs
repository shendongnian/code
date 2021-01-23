    public List<Personel> GetAll(Func<Personel, bool> predicate = null)
            {
                List<Personel> result = new List<Personel>();
    
                if (predicate == null)
                {
                    result = personelRepo.Table.ToList();
                }
                else
                {
                    foreach (var item in personelRepo.Table)
                    {
                        if (predicate(item))
                            result.Add(item);
                    }
                }
    
                return result;
            }
