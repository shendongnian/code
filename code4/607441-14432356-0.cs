    [Test]
    public void Test_AllStringProperties()
	{
		// Linq query to get a list containing all string properties
		var string_props= (from prop in bkvm.GetType()
								.GetProperties(BindingFlags.Public | BindingFlags.Instance)
						  where
							prop.PropertyType == typeof(string) &&
							prop.CanWrite && prop.CanRead
						  select prop).ToList();
		string_props.ForEach(p =>{
									 // Set value of property to a different string
									 string set_val = string.Format("Setting [{0}] to: \"Testing string\".", p.Name);
									 p.SetValue(bkvm, "Testing string", null);
									 Debug.WriteLine(set_val);
									 // Assert it was set correctly
									 Assert.AreEqual("Testing string", p.GetValue(bkvm, null));
									 
									 // Set property to null
									 p.SetValue(bkvm,null,null);
									 set_val = string.Format("Setting [{0}] to null. Should yield an empty string.", p.Name);
									 Debug.WriteLine(set_val);
									 // Assert it returns an empty string.
									 Assert.AreEqual(string.Empty,p.GetValue(bkvm, null));
								 }
			);
	}
