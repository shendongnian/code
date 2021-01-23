    public void conversionButton_Click(object sender, EventArgs e) {
        switch (context.Type) {
            case ConversionType.Csv:
                CSVConversion();
                break;
            case ConversionType.Txt:
                TXTConversion();
                break;
        }
    }
