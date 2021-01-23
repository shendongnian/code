      ItemCollection<Customer> customers = new ItemCollection<Customer>
      customers.BeginUpdate();
      customers.Add( new Customer( "Joe", "Smith" ) );
      customers.Add( new Customer( "Mary", "Jones" ) );
      customers.Add( new Customer( "Lisa", "Black" ) );
      customers.Add( new Customer( "Peter", "Brown" ) );
      customers.EndUpdate();
