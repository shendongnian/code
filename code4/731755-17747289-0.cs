    Chart c = new Chart();
    LineSeries ls = new LineSeries();
    // For new binding you provide it the string path to your property.
    Binding bindInd = new Binding("Key");
    Binding bindDep = new Binding("Value");
    ls.IndependentValueBinding = bindInd;
    ls.DependentValueBinding =bindDep;
