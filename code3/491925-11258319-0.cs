    public static bool nextAllocation<T>(int blockSize, IEnumerable<T> patientDataCollection, Func<T,bool> predicate) 
    { 
        int remainingAllocations = blockSize - patientDataCollection.Count(); 
        if (remainingAllocations == 0) throw new Exception("All alocations within block accounted for"); 
        int remainingInterventions = blockSize/2 - patientDataCollection.Count(predicate); 
        double Pintervention = remainingInterventions / remainingAllocations; 
        double rdm = new Random().NextDouble(); 
        return (rdm <= Pintervention); 
    }
