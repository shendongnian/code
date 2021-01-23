     public void MoveUp()
        {
            var currentIndex = DataItemList.IndexOf(item);
           
            //Index of the selected item
            if (currentIndex > 0)
            {
                int upIndex = currentIndex - 1;
                
                //move the items
                MoveItem(upIndex,currentIndex);
                
            }
        }
