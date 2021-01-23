     bool Is_Egal = true;                 
                 foreach (Pers_Compare Od_Done in Outils.Get_Ordre_Donne())
                 {                    
                     foreach (string Od_Scan in Ordre_Scan)
                     {
                         if (Od_Scan == Od_Done.NoOrdre.ToString() && !String.IsNullOrWhiteSpace(Od_Done.NoOrdre))
                         {
                             Temp_Od_Donne_Egal.Add(Od_Done);
                         }
                         else
                         {
                             Is_Egal = false;
                         }
                     }
                 }
                 Temp_Od_Donne = Outils.Get_Ordre_Donne().Except(Temp_Od_Donne_Egal).ToList();
