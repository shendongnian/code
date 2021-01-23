    var f1 = File.ReadAllLines(@"c:\temp\l1.txt");
    var f2 = File.ReadAllLines(@"c:\temp\l3.txt");
    f1.Select((l, index) => new {Number= index, Text = l})
      .Join(f2.Select((l, index) => new {Number= index, Text = l}), 
      		inner => inner.Number, 
    		outer => outer.Number, 
            (inner, outer) =>  {
    		if(inner.Text == "")
    			return outer.Text;
    		return inner.Text;
      })
      .Concat(f1.Where((l, index) => index >= f2.Count()))
      .Concat(f2.Where((l, index) => index >= f1.Count()))
      .Dump();
