    String x = "matrix1_2";
    Microsoft.VisualBasic.PowerPacks.RectangleShape y;
	Type type = typeof(MyType); // Get type pointer
	FieldInfo[] fields = type.GetFields();
	foreach (var field in fields)
	{
            if (field.Name == "matrix1_2")
            {
                y = field;
            }
    }
