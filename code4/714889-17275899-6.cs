    List<UsageCPU> cpus = (from a in db.UsageCPUs
                          where a.ServerID.Contains(match)
                          group a by a.ServerID into b
                          orderby b.Key
                          select new UsageCPU  //Added UsageCPU  
                          { 
                              ServerID = b.Key, 
                              Usage = b.FirstOrDefault().Usage 
                          }).ToList();
