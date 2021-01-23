    partial void VidContentItemsGrid_Activated() {
      int index = 0;
      foreach (var item in this.VidContentItems) {
        if (item.Active == false) {
          this.FindControlInCollection("TrueIconInd", this.VidContentItems.ElementAt(index)).IsVisible = false;
        }
        index++;
      }
    }
