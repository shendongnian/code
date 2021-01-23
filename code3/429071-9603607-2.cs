    void Timer_Tick(...)
    {
     if (Notes.Count < 10)
       Notes.Add(new Note{Frecuency = 900});
    }
