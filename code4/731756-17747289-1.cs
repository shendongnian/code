    Chart c = new Chart();
    LineSeries ls = new LineSeries();
    // For new binding you provide it the string path to your property.
    Binding bindInd = new Binding("Key");
    Binding bindDep = new Binding("Value");
    // then you can set the properties of your binding like so
    bindInd.Source = <your source>;
    bindDep.Source = <Your Source>;
    bindDep.Mode = BindingMode.OneWay;
    bindInd.Mode = BindingMode.OneWay;
    ls.IndependentValueBinding = bindInd;
    ls.DependentValueBinding =bindDep;
