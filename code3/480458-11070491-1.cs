    public static class MapLayerExtensions
    {
        private static DependencyProperty ForceMeasureProperty =
            DependencyProperty.RegisterAttached("ForceMeasure",
                                                typeof(int),
                                                typeof(MapLayerExtensions),
                                                new FrameworkPropertyMetadata(0,
                                                    FrameworkPropertyMetadataOptions.AffectsRender |
                                                    FrameworkPropertyMetadataOptions.AffectsArrange |
                                                    FrameworkPropertyMetadataOptions.AffectsMeasure));
        private static int GetForceMeasure(DependencyObject mapLayer)
        {
            return (int)mapLayer.GetValue(ForceMeasureProperty);
        }
        private static void SetForceMeasure(DependencyObject mapLayer, int value)
        {
            mapLayer.SetValue(ForceMeasureProperty, value);
        }
        public static void ForceMeasure(this MapLayer mapLayer)
        {
            SetForceMeasure(mapLayer, GetForceMeasure(mapLayer) + 1);
        }
    }
