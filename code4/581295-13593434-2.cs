    public static Gracz UstawAktywnegoGracza(List<Gracz> listagraczy, int ID)
    { 
       return listagraczy
               .FirstOrDefault(item => item.Id == 3 && (ID != 4 || item.czyAktywny));
    }
