    public void List<T> GetMammals<T>(T mammal) where  T : Mammal
    {
       GetMammalsSpecialization(mammal as dynamic);
    }
    
    private void List<Horse> GetMammalsSpecialization(Horse horse)
    {
        // Specialized code to return list of horses
    }
    
    private void List<Cow> GetMammalsSpecialization(Cow cow)
    {
        // Specialized code to return list of cows
    }
