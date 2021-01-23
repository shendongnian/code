    public partial class Form2 : Form
    {
        public string[] fulldate {get; set;} // Create a Property
       
        void CloseForm()
        {
             fulldate = "valueToReturn";
             DialogResult = DialogResult.OK;
        }
    }
