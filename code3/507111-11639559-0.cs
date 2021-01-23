    public partial class Employees : Form 
    { 
        DataSet[]drRow = tblEmployees.Select("EmployeeKey = " + TextBox12.Text);; 
        public Employees() 
        { 
    // etc, etc.
