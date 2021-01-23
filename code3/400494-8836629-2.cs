    void AddButton_Click(object sender, EventArgs e)
    {
        var newItem = new SomeItem
            {
                Name = "Something",
                City = "Something",
                Age = 30,
                Count = 2,
                IsM1Visible = true,
                IsM2Visible = false,
                IsM3Visible = true
            };
    
        SomeCollection.Add(newItem);
    }
