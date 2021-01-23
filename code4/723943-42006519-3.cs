	protected void saveRelatedConnectors(test_engine testEngine, List<int> connectorTypes)
        var stepConnectorsToDelete = testEngine.step_connector.Where(x => (connectorTypes.Count == 0) || 
            (connectorTypes.Count != 0 && !connectorTypes.Contains(x.id)));
        stepConnectorsToDelete.ToList().ForEach(x =>
        {
            testEngine.step_connector.Remove(x);
        });
        
        var stepConnectorsToAdd = entities.step_connector.Where(x => connectorTypes.Contains(x.id));
        stepConnectorsToAdd.ToList().ForEach(x =>
        {
            testEngine.step_connector.Add(x);
        });
        
        entities.SaveChanges();
