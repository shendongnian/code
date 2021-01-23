    string id = .....;
    string columnA= txtA.Text;
    strign columnB = txtB.Text;
    var service = new ParentService();
    ParentEntity parent = service.Update(id, columnA, columnB);
