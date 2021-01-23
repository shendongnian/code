    // Add IMessageFilter to the form
    public partial class Form1 : Form, IMessageFilter
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0100)
                {
            {
                DataView dv = glObalDataSet.Tables["JOBURI"].DefaultView;
                dv.RowFilter = "CONT = '" + comboBox1.SelectedValue.ToString() + "'";
                comboBox2.DataSource = LoadDataTable(dv);
                comboBox2.DisplayMember = "JOB";
                comboBox2.AutoCompleteCustomSource = LoadAutoComplete("JOB", dv);
                comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    return true;
                }
            return false;
        }
