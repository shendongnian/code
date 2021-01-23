        /// <summary>
        /// Defines if the tile has two sides.
        /// </summary>
        public bool IsTwoSided
        {
            get { return (bool)GetValue(IsTwoSidedProperty); }
            set
            {
                SetValue(IsTwoSidedProperty, value);
                this.startAnimations();
            }
        }
