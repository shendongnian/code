    private void submit_Click(object sender, EventArgs e)
    {
            var newPerson = new Person(personName.Text, personLName.Text);
            newPerson.housesOwned.AddRange(houseList);
            person.Add(newPerson);
            MessageBox.Show("Done!");
    }
