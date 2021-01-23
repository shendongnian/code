    public virtual void AddMediciones(List<Medicion> TodasMediciones)
            {
                int i = 0;
                foreach (Medicion m in TodasMediciones)
                {
                    Console.WriteLine(Mediciones.Contains(m));
                    Console.WriteLine(m.Valor);
                    Console.WriteLine("-------------------------------------------");
                    if (!Mediciones.Contains(m))
                    {
                        Mediciones.Add(m);
                    }
                }
            }
