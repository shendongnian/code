    this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
    this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
    RNProveedor rnProveedor = new RNProveedor();
    var listaProveedores = rnProveedor.Buscar();
    Dictionary<int, String> dicTemp = new Dictionary<int, string>();
    foreach (var entidad in listaProveedores)
    {
        dicTemp.Add(entidad.ProvNro, entidad.ProNombre);
    }
    this.DataSource = new BindingSource(dicTemp, null);
    this.DisplayMember = "Value";
    this.ValueMember = "Key";
