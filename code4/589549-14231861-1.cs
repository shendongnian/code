      private void InvoiceGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                ((ResolutionVM)this.DataContext).PrepareListForMassUpdate();
            }
            else
            {
                ((ResolutionVM)this.DataContext).ClearListForMassUpdate();
            }
        }
