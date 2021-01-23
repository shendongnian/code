    privete bool itemSelected = false;
    private void listBox1_SelectedItemChanged(object sender, EventArg e)
    {
        if(itemSelected == false)
        {
            // select the item of listBox1
            itemSelected = true;
         }
         else
         {
            // Clear items of listBox2
            itemSelected = false;
          }
      }
      private void listBox2_SelectedItemChanged(object sender, EventArg e)
      {
          if(itemSelected == false)
          {
               // select the item of listBox2
               itemSelected = true;
          }
          else
          {
                // Clear items of listBox1
                itemSelected = false;
          }
      }
