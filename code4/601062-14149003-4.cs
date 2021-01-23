        public class ButtonTemplateSelector : DataTemplateSelector
    {
        #region Member Variables
        #endregion
        #region Ctr
        public ButtonTemplateSelector()
        {
        }
        #endregion
        #region Overrides
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is SquareDesert)
            {
                return Desert;
            }
            if (item is SquareMountain)
            {
                return Mountain;
            }
            if (item is SquarePrairie)
            {
                return Prairie;
            }
            return base.SelectTemplate(item, container);
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        #endregion
        #region Properties
        public DataTemplate Mountain
        {
            get;
            set;
        }
        public DataTemplate Desert
        {
            get;
            set;
        }
        public DataTemplate Prairie
        {
            get;
            set;
        }
        #endregion
    }
