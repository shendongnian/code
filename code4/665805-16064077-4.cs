    var items = context.Items.GroupBy(g => new {g.Name, g.Model, g.SerialNumber })
                .Where(/*...*/) 
                .Select(i => new ItemModel {
                        Name=g.Key.Name,
                        SerialNumber = g.FirstOrDefault().SerialNumber //<-- here
                 });
