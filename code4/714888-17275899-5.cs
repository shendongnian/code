    List<UsageCPU> cpus = (from a in db.UsageCPUs
                          where a.ServerID.Contains(match)
                          group a by a.ServerID into b
                          orderby b.Key
                          select new 
                          { 
                              ServerID = b.Key, 
                              Usage = b.FirstOrDefault(x => x.Usage ) 
                          })
						.AsEnumerable()
						.Select(x => new UsageCPU  
						{
						   ServerID ,
						   Usage            
						}).ToList();
