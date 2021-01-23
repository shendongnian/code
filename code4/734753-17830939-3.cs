    //rember the selection of the index
    private int _currentIndex;
    private bool _rollingBackSelection;
   
    private void SelectionChanged(...){
         //when changing back to the selection in dgv1 prevent dgv2 check
         if (_rollingBackSelection) {
             _rollingBackSelection = false;
             return;
         }
         if (dgv2IsDirty()) {
              var result = MessageBox.Show("Ok?", "Save?", MessageBoxButtons.YesNoCancel);
              if (result == DialogResult.Cancel) {
                 _rollingBackSelection = true;
                 //rollback to the previous index
                 dgv1.Rows[_currentIndex].Selected = true;
                 return;
              }
              if (result == DialogResult.Yes)
                 dgv2Save();
             dgv2Load();
             _currentIndex = dgv1.SelectedRows[0].Index;
         }
    }
