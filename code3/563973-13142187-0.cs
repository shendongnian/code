        private void IngredientsListBox_LayoutUpdated(object sender, EventArgs e)
        {
            if (ingredientsListLoaded)
            {
                activatePieceQuantity();
                ingredientsListLoaded = false;
            }
        }
