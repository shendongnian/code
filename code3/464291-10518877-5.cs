	private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		path = (string)listBox1.SelectedItem;
		DisplayFile(path);
	}  
 
	private void DisplayFile(string path)
	{
		string xmldoc = File.ReadAllText(path);
		
		while (reader.MoveToNextAttribute())
		{
		  switch (reader.Name)
		  {
			case "description":
			  if (!string.IsNullOrEmpty(reader.Value))
				label_description.Text = reader.Value; // your label name
			  break;
			case "sourceId":
			  if (!string.IsNullOrEmpty(reader.Value))
				label_sourceId.Text = reader.Value; // your label name
			  break;
			// ... continue for each label
		   }
		}
	}
