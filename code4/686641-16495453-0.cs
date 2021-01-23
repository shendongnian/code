    BunchOfDeliverables bunchOfDeliverables = new BunchOfDeliverables();
    bunchOfDeliverables.LoadPersonsFromFile(personsFile);
    bunchOfDeliverables.LoadDeliverablesFromFile(deliverablesFile);
    listBox.DataSource = bunchOfDeliverables.Persons;
    listBox.DisplayMember = "<Whatever>";
    listBox.ValueMember = "<Whatever>";
    // OR
    listBox.DataSource = bunchOfDeliverables.Deliverables;
    listBox.DisplayMember = "<Whatever>";
    listBox.ValueMember = "<Whatever>";
