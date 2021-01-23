      public void llenarTabla()
        {
    
            int idx;
            List<string> linea=new List<string>();
            for (idx = 0; idx < numListas; idx++)
            {
                linea.Add(Convert.ToString(idx)); // (2)
                switch(OrdenListas[idx]){
                    case 0: linea.Add("Crescente"); break;
                    case 1:linea.Add("Decrescente"); break;
                    case 2: linea.Add("Aleatorio"); break;
                    default:linea.Add("No especificado" ); break;
                }
               linea.Add(Convert.ToString(LongitudListas[idx]));
            }
        }
