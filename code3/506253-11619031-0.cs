     List<Dx> dxs = new List<Dx>();
     dxs.Add(new Dx());
     dxs.Add(new Dx());
    
     List<Proc> procs = new List<Proc>();
     procs.Add(new Proc());
    
     List<IEnumerable<IClean>> lists = new List<IEnumerable<IClean>>();
     lists.Add(procs); 
     lists.Add(dxs); 
    
     foreach (List<IClean> list in lists)
     {
         foreach (IClean i in list)
         {        
             i.Clean();
         }
     }
