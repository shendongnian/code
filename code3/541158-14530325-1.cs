     public void MoveUp()
        {
            var currentIndex = DataItemList.SelectedIndex;
           
            //Index of the selected item
            if (currentIndex > 0)
            {
                int upIndex = currentIndex - 1;
                
                //move the items
                DataItemList.MoveItem(upIndex,currentIndex);
                
            }
        }
