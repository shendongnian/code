	string filmID = comboBox1.SelectedValue.ToString();
	Scenario newScenario = new Scenario();
	foreach (Scenario scenario in myDatabase.Scenario
		.Where(scn => scn.filmID.ToString().Equals(filmId))
	{
		scenario.SceneWriter.Add(newScenewriter);before
	}
	myDatabase.SaveChanges();
