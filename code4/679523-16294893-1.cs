    public interface IMyView
    {
        string FirstName { get; }
        string HouseName { get;}
        string CountrySelection { get; }
    }
    public class MyView : Form, IMyView
    {
        public string FirstName { get { return this.FirstName.Text; } } // Textbox
        public string HouseName { get { return this.HouseName.Text; } } // Textbox
        public string CountrySelection { get { return this.CountryList.Text; } // Combobox
    }
