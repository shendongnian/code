    // hack
    var b = new SolidBrush(System.Drawing.Color.FromArgb(255, 255, 235, 205));
	var colorname = (from p in typeof(System.Drawing.Color).GetProperties()
					 where p.PropertyType.Equals(typeof(System.Drawing.Color))
					 let value = (System.Drawing.Color)p.GetValue(null, null)
					 where value.R == b.Color.R &&
					 	   value.G == b.Color.G &&
					 	   value.B == b.Color.B &&
					 	   value.A == b.Color.A
					 select p.Name).DefaultIfEmpty("unknown").First();
    // colorname == "BlanchedAlmond"
