    private void Chbox_Click(object sender, RoutedEventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        string name = chk.Name;
        if (name == "chbox_pres")
        {
            valor_pres = chbox_pres.IsChecked ?? false;
            chbox_dev.IsChecked = !valor_pres;
            valor_dev = !valor_pres;
            Debug.WriteLine("<< pres: pres = " + valor_pres + ", dev= " + valor_dev);
        }
        else
        {
            valor_dev = chbox_dev.IsChecked ?? false;
            chbox_pres.IsChecked = !valor_dev;
            valor_pres = !valor_dev;
            Debug.WriteLine("<< dev: pres = " + valor_pres + ", dev= " + valor_dev);
        }            
    }      
     
