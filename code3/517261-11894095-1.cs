    void loadSharePricesComboBox(string fileName) {
        using (StreamReader sr = new StreamReader(fileName)) {
            while (!sr.EndOfStream) {
                comboComSymbol.Items.Add(sr.ReadLine());
            }
        }
    }
