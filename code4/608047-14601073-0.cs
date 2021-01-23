    public class GridWithSemanticZoomInformation : Grid , ISemanticZoomInformation
    {
        private SemanticZoom _semanticZoomOwner;
        private Boolean _IsZoomedInView;
        private Boolean _IsActiveView;
        public void CompleteViewChange()
        {
            //
        }
        public void CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            this.IsActiveView = false;
        }
        public void CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            this.IsActiveView = true;
                
        }
        public void InitializeViewChange()
        {
            //
        }
        public bool IsActiveView
        {
            get
            {
                return this._IsActiveView;
            }
            set
            {
                this._IsActiveView = value;
            }
        }
        public bool IsZoomedInView
        {
            get
            {
                return this._IsZoomedInView;
            }
            set
            {
                this._IsZoomedInView = value;
            }
        }
        public void MakeVisible(SemanticZoomLocation item)
        {
            this.SemanticZoomOwner.IsZoomedInViewActive = (this.Equals(this.SemanticZoomOwner.ZoomedInView));
            if (item.Bounds.Left != 0.5)
            {
                if (this.Children.Count() == 1)
                {
                    foreach (UIElement element in this.Children)
                    {
                        if (element.GetType() == typeof(ScrollViewer))
                        {
                            ((ScrollViewer)element).ScrollToHorizontalOffset(item.Bounds.Left);
                        }
                    }
                }
            }
        }
        public SemanticZoom SemanticZoomOwner
        {
            get
            {
                return this._semanticZoomOwner;
            }
            set
            {
                this._semanticZoomOwner = value;
            }
        }
        public void StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            //
        }
        public void StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            //
        }
    }
