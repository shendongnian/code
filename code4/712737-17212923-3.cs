	var descriptionNode = rootNode.SelectSingleNode("//div[@id='description']");
	var entireDescription = descriptionNode.InnerText.Trim();
	var splitUpDescriptionParts =
		entireDescription.Split(
			new[]
				{
					"More Details about this Used Car:", "Body Condition:", "Mechanical Condition:", "Doors:", "Cylinders:", "Body Style:",
					"Drive Type:", "Warrenty:", "Description:"
				},
			StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s));
	string bodyCondition = splitUp.First();
	string mechancialCondition = splitUp.ElementAt(1);
	string amountOfDoors = splitUp.ElementAt(2);
	string amountOfCylinders = splitUp.ElementAt(3);
	string bodyStyle = splitUp.ElementAt(4);
	string driveType = splitUp.ElementAt(5);
	string warranty = splitUp.ElementAt(6);
	string description = splitUp.Last();
