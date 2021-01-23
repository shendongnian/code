    public interface IDepartmentChanged
    {
       void DepartmentChanged(int departmentId);
    }
    public class UserControl1 : UserControl, IDepartmentChanged
    {
        public void DepartmentChanged(int departmentId)
        {
          // refresh data
        }
    }
    public class Form1 : Form
    {
       // Add all UserControls to a List  => _controls 
       private List<UserControl> _controls = new List<UserControl>();
       public Form1()
       {
           InitializeComponent();
           _controls.Add(userControl11);
       }
       private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
       {
            int selectedDepartmentId = ((MyData)comboBox1.SelectedValue).Id;
            foreach (UserControl control in _controls)
                if (control is IDepartmentChanged)
                    ((IDepartmentChanged)control).DepartmentChanged(selectedDepartmentId);
            // or even shorter:
            foreach (IDepartmentChanged departmentChanged in _controls.OfType<IDepartmentChanged>())
                departmentChanged.DepartmentChanged(selectedDepartmentId);
       }
