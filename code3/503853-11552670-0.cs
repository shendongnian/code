    public class YourController
    {
        public DataGridView MyView { get; set; }
        //The method to add a row
        public void AddRowToView(string passedText)
        {
            using (Form2 f2 = new Form2())
            {
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    MyView.Rows.Add(passedText, f2.txEdit.Text);
                }
            }
        }
    }
