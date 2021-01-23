    	[TestFixture]
	public class SerializeTest
	{
		[Test]
		public void TestSer()
		{
			var parent = new Parent
			             	{
			             		Name = "Test"
			             	};
			parent.Children.Add("Child1", new Child {Name = "Child1"});
			parent.Children.Add( "Child2", new Child { Name = "Child2" } );
			SerialiseObject(parent, "test.bin");
			var copy = DeserialiseObject("test.bin") as Parent;
			Assert.IsNotNull(copy);
			Assert.AreEqual(2, copy.Children.Count);
			Assert.IsTrue(copy.Children.ContainsKey("Child1"));
			Assert.AreEqual("Child1", copy.Children["Child1"].Name);
		}
		static void SerialiseObject( Object o, String path )
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream( path, FileMode.Create );
			formatter.Serialize( stream, o );
			stream.Close();
		}
		static Object DeserialiseObject( String path )
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream( path, FileMode.Open, FileAccess.Read );
			Object o = (Object) formatter.Deserialize( stream );
			stream.Close();
			return o;
		}
		[Serializable]
		private class Parent
		{
			public string Name { get; set; }
			public Dictionary<string, Child> Children { get; protected set; }
			public Parent()
			{
				Children = new Dictionary<string, Child>();
			}
		}
		[Serializable]
		private class Child
		{
			public string Name { get; set; }
		}
	}
