    if (comboBox1.SelectedItem != null)
                {
                    int x = int.Parse(comboBox1.SelectedItem.ToString());
    
                    var subDeptInfo =GetDepartmentInfo(x);   
                    textBox2.Text = subDeptInfo[0].sdCode.ToString();
                    textBox3.Text = subDeptInfo[0].sdName;
                    textBox4.Text = subDeptInfo[0].dpCode.ToString();
                }
                else { //Value is null }
