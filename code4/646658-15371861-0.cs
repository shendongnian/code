    private void AddSubCategories2(int from, int to)
    {
           for (int i = from; i < to; i++)
            clbSubCategories2.Items.Add(strSubCategories2[i]);
           
           if(checkedItems!=null)
              foreach(string item in checkedItems)
              { 
                clbSubCategories2.Items.FindByText(item).Selected = true;
              }
    }
