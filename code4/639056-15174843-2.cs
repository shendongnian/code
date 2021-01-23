    public class Medicion : Modelo<Medicion>
        {
            public virtual DateTime Fecha { get; set; }
            public virtual decimal Valor { get; set; }
            public virtual Indicador Indicador { get; set; }
        }
    }
