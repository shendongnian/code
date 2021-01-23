    for(int i = mainForm.Controls.Count - 1; i >= 0; i--){
      if(mainForm.Controls[i] is Panel){
         mainForm.Controls.RemoveAt(i);
      }
    }
