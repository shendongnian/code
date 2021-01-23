        private ItemsPresenter itemsPresenter;
        public CustomFlipView()
        {
            this.DefaultStyleKey = typeof(CustomFlipView);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            itemsPresenter = GetTemplateChild("FlipViewItemsPresenter") as ItemsPresenter;
            FixateItems();
        }
        protected override void OnItemsChanged(object e)
        {
            base.OnItemsChanged(e);
            FixateItems();
        }
        private void FixateItems()
        {
            if (itemsPresenter != null)
            {
                if (this.Items.Count < 2)
                {
                    itemsPresenter.ManipulationMode = ManipulationModes.None;
                }
                else
                {
                    itemsPresenter.ManipulationMode = ManipulationModes.System;
                }
            }
        }
    }
