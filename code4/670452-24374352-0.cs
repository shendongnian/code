		public sealed class MyClassMap : CsvClassMap<MyClass>
		{
			public MyClassMap(ClassType type)
			{
				switch (type)
				{
					case ClassType.TypeOdd
						Map(m => m.Field1);
						Map(m => m.Field3);
						Map(m => m.Field5);					
						break;
					case ClassType.TypeEven:
						Map(m => m.Field2);
						Map(m => m.Field4);
						Map(m => m.Field6);					
						break;
					case ClassType.TypeAll:
						Map(m => m.Field1);
						Map(m => m.Field2);
						Map(m => m.Field3);
						Map(m => m.Field4);
						Map(m => m.Field5);
						Map(m => m.Field6);					
						break;
				}
			}
		}
