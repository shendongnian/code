        public void foucusItem( ListView.Item itemToFocusIndex){
             int count = 0; 
             foreach(ListView.Item item in YourListView){
                   if(item == itemsToFocusIndex){
                         ListView.Items[count].Focus();
                         return;
                   }
             count++;
             }
        }
