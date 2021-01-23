        new Series{
         Name = "Employees",
         Data  = new Data(
            dataItems.Select(y => new Point { 
             Color = System.Drawing.Color.FromName(y.Item1), 
             Y = (int)y.Item2 }).ToArray()
            )               
         }
