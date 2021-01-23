	var tat = new ThisAndThat();
	tat.This = 1;
	tat.That = 2.0F;
	tat.TheOther = 3.0;
	tat.Whatever = "Whatever";
	var type = typeof(ThisAndThat);
	var properties = type.GetProperties();
	double total = 0.0;
	foreach (System.Reflection.PropertyInfo pi in properties)
	{
		switch (pi.PropertyType.ToString())
		{
			case "System.Int32": //int
				total += (int) pi.GetValue(tat, null);
				break;
			case "System.Double":
				total += (double) pi.GetValue(tat, null);
				break;
			case "System.Single": //float
				total += (float) pi.GetValue(tat, null);
				break;
		}
	}
	MessageBox.Show(total.ToString());
