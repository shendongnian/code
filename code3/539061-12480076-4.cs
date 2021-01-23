    public void myFunc(BackgroundWorker bgw)
    {
        foreach (string Client in Clients)
        {
           // Do something
           // Return Client and insert into listview, richtextbox, W/E
           var returningObjects = List<string>();  //I assume this will be a list of strings based on your question.
           returningObjects.Add(ClientName);
           returningObjects.Add(ClientOrder);
           returningObjects.Add(Client3rdThing);
           bgw.ReportProgress(0,returningObjects)
        }
    } 
