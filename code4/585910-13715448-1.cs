    public partial class Form1 : Form
    {
        private class Person
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public override string ToString()
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
        public Form1()
        {
            this.InitializeComponent();
            this.mainListBox.SelectionMode = SelectionMode.One;
            this.PopulateListBox();
        }
        private void PopulateListBox()
        {
            this.mainListBox.Items.Add(new Person() { FirstName = "Joe", LastName = "Smith" });
            this.mainListBox.Items.Add(new Person() { FirstName = "Sally", LastName = "Jones" });
            this.mainListBox.Items.Add(new Person() { FirstName = "Billy", LastName = "Anderson" });
        }
        private void upButton_Click(object sender, EventArgs e)
        {
            if (this.mainListBox.SelectedIndex > 0)
            {
                int selectedIndex = this.mainListBox.SelectedIndex;
                object selectedItem = this.mainListBox.SelectedItem;
                this.mainListBox.Items.RemoveAt(selectedIndex);
                this.mainListBox.Items.Insert(selectedIndex - 1, selectedItem);
                this.mainListBox.SelectedIndex = selectedIndex - 1;
            }
        }
        private void downButton_Click(object sender, EventArgs e)
        {
            if (this.mainListBox.SelectedIndex > -1 &&
                this.mainListBox.SelectedIndex < this.mainListBox.Items.Count - 1)
            {
                int selectedIndex = this.mainListBox.SelectedIndex;
                object selectedItem = this.mainListBox.SelectedItem;
                this.mainListBox.Items.RemoveAt(selectedIndex);
                this.mainListBox.Items.Insert(selectedIndex + 1, selectedItem);
                this.mainListBox.SelectedIndex = selectedIndex + 1;
            }
        }
    }
