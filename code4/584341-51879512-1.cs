    //class to store ID (Pri. Key) value of selected row from DataGridView
    public class Variables
    {
       public static string StudentID;
    }                                  
    
    //This is the event call on cell click of the DataGridView
    private void dataGridViewDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
    {
       Variables.StudentID =this.dataGridViewDisplay.CurrentRow.Cells[0].Value.ToString();
    //textBoxName is my form field where I set the value of Name Column from the Selected row from my DataGridView 
       textBoxName.Text = this.dataGridViewDisplay.CurrentRow.Cells[1].Value.ToString();
                
       dateTimePickerDOB.Value = Convert.ToDateTime(this.dataGridViewDisplay.CurrentRow.Cells[2].Value.ToString());
    }
