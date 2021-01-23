        Dictonary<string, List<int>> dictonary = op.startCollecting();
        if(dictonary.ContainsKey("Henvendelser"))
        {
            List<int> list = dictonary["Henvendelser"];
            int value = list[0];
            MessageBox.Show(value.ToString());
        }
