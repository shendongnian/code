    CustomerValidator validator = new CustomerValidator();
    ValidationResult results = validator.Validate(customerToInsert);
    if(results.IsValid){
        using (var con = new SqlConnection(ConnectionString.GetWebTablesConnectionString()))
            using (var cmd = new SqlCommand("InsertNewCustomer", con))
            {
                //Do the actual insert / SP call here, your object is valid
            }
        }
    }
