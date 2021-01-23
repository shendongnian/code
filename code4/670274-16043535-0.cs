        string filmID = comboBox1.SelectedValue.ToString();
        Scenario newScenario = new Scenario();
        foreach (Scenario scenario in scenarioes)
        {
            string thisID = scenario.filmID.ToString();
            if (thisID.Equals(filmID))
            {
                try
                {
                    scenario.SceneWriter.Add(newScenewriter);
                    myDatabase.SaveChanges();
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.ToString());
                }
            }
        }
