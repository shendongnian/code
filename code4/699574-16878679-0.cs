    class YourViewModel {
        public bool ShouldExpand {
            get {
                return _theCollectionYouPopulatedTheGridWith.Length() != 0;
                // or maybe use a flag, you get the idea !
            }
        }
        public void ButtonPressed() {
            // populate the grid with collection
            // NOW RAISE PROPERTY CHANGED EVENT FOR THE ShouldExpand property
        }
    }
