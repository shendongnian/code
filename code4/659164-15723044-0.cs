	var pred = Predicate.True<Customer>();
	pred = pred.And(c => c.lastname.Equals(_customer.lastName, StringComparison.InvariantCultureIgnoreCase);
	pred = pred.And(c => c.firstname.Equals(_customer.firstName, StringComparison.InvariantCultureIgnoreCase);
	pred = pred.And(c => c.DOB.ToString("yyyyMMdd").Equals(_customer.DOB.ToString("yyyyMMdd"));
	var customersFound = _repo.Customers.Where(pred.Expand());
