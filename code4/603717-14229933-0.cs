    public class TariffConfigMap : EntityBaseMap<TariffConfig>
    {
        public TariffConfigMap() : base()
        {
           this.Initialize("TariffConfig");
           References(prop => prop.Determinator)
                .ColumnName("TariffDeterminatorCd");           
        }
    }
