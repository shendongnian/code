    private void LoadData()
    {
        using (var db = new WhateverYourContextNameIs()) {
            siparisBindingSource.DataSource = db.Siparis.Include("Kazan").ToList();
        } 
    }
