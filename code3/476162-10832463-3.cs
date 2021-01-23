     if (this.Gender == person.Gender)
     {
          return false;  // Unless the village is New York or Brighton :)
     }
     if (!person.Alive)
     {
          return false;  // Unless vampires/zombies are allowed
     }
     if (Partner != null)
     {
          return false;  // Unless village supports bigamy/poligamy in which case use a collection for Partner and rename to Partners.
     }
