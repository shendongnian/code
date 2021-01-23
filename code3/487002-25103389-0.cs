    using ServiceStack.Text;
    ...
    var csv = CsvSerializer.SerializeToCsv(new[]{
        new Dog () {
        Bark = "Woof!",
        Male = true,
        Size = 10
    }});
