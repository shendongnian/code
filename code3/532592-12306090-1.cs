    public static class ProductionLineGroupFormatterFactory {
      public static ProductionLineGroupFormatter<TissueProductionLine> GetProductionLineGroupFormatter(ProductionLineGroup<TissueProductionLine> group) {
        return new TissueProductionLineGroupFormatter();
      }
      // .. other factory methods....
    }
