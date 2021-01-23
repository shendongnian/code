	//	simple example
	ITransaction t = TransactionFactory.GetNewTransaction();
	t.begin();
	try{
		//	create person entity
		personRepository.Add(person, t);
		//	create cars assigned to person
		carRepository.AddRange(cars, t);
		t.commit();
	}catch(Exception){
		t.rollback();
	}
