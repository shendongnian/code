    class yourClass
    {
		WebSphereUI webSphereUi = new WebSphereUI();
		...
		private void yourFunction()
		{
			for (int i = 1; i <= numberOfMsgs; i++)
			{
				if (addDateTime.AddMinutes(2).Minute==DateTime.Now.Minute)
				{
					webSphereUi.count(fiveMinutesCount);
					webSphereUi.Show();
					addDateTime = DateTime.Now;
				}
				fiveMinutesCount = fiveMinutesCount + 1;
			}
		}
	}
