    public void Feed(Mammal mammal) {
        if (mammal is Duck) 
        {
            ((Duck)mammal).PryOpenBeak();
            ((Duck)mammal).InsertFeedingTube();
            ((Duck)mammal).PourDownFood();
        }
    }
