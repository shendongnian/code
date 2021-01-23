	[Test]
	public void InsertOrUpdate1()
	{
		ForEachProvider(db =>
		{
			var id = 0;
			try
			{
				id = Convert.ToInt32(db.Person.InsertWithIdentity(() => new Person
				{
					FirstName = "John",
					LastName  = "Shepard",
					Gender    = Gender.Male
				}));
				for (var i = 0; i < 3; i++)
				{
					db.Patient.InsertOrUpdate(
						() => new Patient
						{
							PersonID  = id,
							Diagnosis = "abc",
						},
						p => new Patient
						{
							Diagnosis = (p.Diagnosis.Length + i).ToString(),
						});
				}
				Assert.AreEqual("3", db.Patient.Single(p => p.PersonID == id).Diagnosis);
			}
			finally
			{
				db.Patient.Delete(p => p.PersonID == id);
				db.Person. Delete(p => p.ID       == id);
			}
		});
	}
