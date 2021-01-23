    public Class YourClass
    {
        public string Name;
        {
           get;
           private set;
        }
        
        public string PhoneNo;
        {
           get;
           private set;
        }
        
        public override string ToString()
        {
           return String.Format("{0,-50} {1,-15}", this.Name, this.PhoneNumber);
        }
    }
    internal class YourForm : Form
    {
        ComboBox YourComboBox = new Combobox();
        //Set the style of your combobox such that it looks like a text box
        BindingList<KeyValuePair<string, YourClass> bl = new Binding<string, YourClass>();
        
        //Query for the data to populate the BindingList
        //Lets say you put the UserId or ContactId of the person in the Key..        
        YourComboBox.DataSource = bl; 
        YourComboBox.DisplayMember = "Value";
        YourComboBox.ValueMember = "Key";     
    }
