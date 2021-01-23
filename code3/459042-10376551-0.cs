        // Use a function that takes a StringReader as an input.
        // That way you can supply test data without using the Console class.
        static StockItem[] ReadItems(StringReader input)
        {
          var stock = new List<StockItem>();
        
          // Only call ReadLine once per iteration of the loop.
          // I expect this is why you're not getting all the data.
          string line = input.ReadLine();
          while( ! string.IsNullOrEmpty(line) ) {
        
            int id;
            // Use int.TryParse so you can deal with bad data.
            if( int.TryParse(line, out id) ) { 
              stock.Add(new Stock(id));
            }
        
            line = input.ReadLine();
          }
          // No need to build an populate an array yourself. 
          // There's a linq function for that.
          return stock.ToArray();
        }
