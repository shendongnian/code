	//Deserialize the JSON-encoded data into a new instance of Person by using the ReadObject method of the DataContractJsonSerializer.
	stream1.Position = 0;	
	Person p2 = (Person)ser.ReadObject(stream1);
	
	//Show the results.
	
	Console.Write("Deserialized back, got name=");
	Console.Write(p2.name);
	Console.Write(", age=");
	Console.WriteLine(p2.age);
