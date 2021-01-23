    public class StringValue
    {
        public StringValue(string s)
        {
            _value = s;
        }
        public string Value { get { return _value; } set { _value = value; } }
        string _value;
    }
    List<StringValue> lstContacts = new List<StringValue>();
    lstContacts.Add("your email address");
    dataGridView1.DataSource = lstContacts;
    dataGridView1.Show();
