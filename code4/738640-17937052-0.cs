    public class Item {
       public string FullName {get;set;}
       public string ID {get;set;}
    }
    //your array of Item
    Item[] items = ...
    //Bind your array to your combobox
    comboBox.DataSource = items;
    comboBox.DisplayMember = "FullName";
    comboBox.ValueMember = "ID";
