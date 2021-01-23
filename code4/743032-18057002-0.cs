	IList<IWebElement> list = elements;
	foreach (IWebElement opt in list)
	{
		dur = elements[0].Text.ToString();
		price = elements[1].Text.ToString();
		MessageBox.Show(dur);
		MessageBox.Show(price);
	}
