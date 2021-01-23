    public class DataGridLiteTextColumn : DataGridColumn
    {
        private readonly PropertyDescriptor property;
    
        private readonly GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\Arial.ttf"));
    
        public DataGridLiteTextColumn(PropertyDescriptor property)
        {
            this.property = property;
        }
    
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var value = property.GetValue(dataItem);
            return new LiteTextBlock(new Size(100, 20), value != null ? value.ToString() : string.Empty, this.glyphTypeface, 10);
        }
    
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            throw new NotImplementedException();
        }
    }
