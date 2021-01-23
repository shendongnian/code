    // disable editing
    
    private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {
    
        GridView view = sender as GridView; 
            e.Cancel = view.FocusedRowHandle == 0;
    }
