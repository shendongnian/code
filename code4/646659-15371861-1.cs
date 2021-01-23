    private void AddSubCategories2(int from, int to)
    {
           for (int i = from; i < to; i++)
            clbSubCategories2.Items.Add(strSubCategories2[i]);
           
           if(checkedItems!=null)
              foreach(string item in checkedItems)
              { 
                  int index=  clbSubCategories2.FindStringExact(item);
                  if(index>-1)
                    clbSubCategories2.SetItemChecked(index, true);
              }
    }
