		public class Message
		{
			[Key]
			public int Id { get; set; }
			public string Title { get; set; }
			[Column(TypeName = "jsonb")]
			[JsonIgnore]
			public string JMyClass { get; set; }
			[NotMapped]
			public MyClass JsonDefinition 
			{
				get => JsonConvert.DeserializeObject<MyClass>(JMyClass );
				set => JMyClass = JsonConvert.SerializeObject(value);
			}
		}
