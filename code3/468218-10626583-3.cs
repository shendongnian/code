    Customer c4 = new Customer(p); //conversion constructor
    Customer c5 = p.ToCustomer(); //conversion method
    Customer c6 = (Customer) p; // if defined, implicit conversion. Otherwise, casting
                                // yes, casting and implicit conversion are the same syntax
                                // terribly confusing.
