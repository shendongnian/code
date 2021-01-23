    public class BindingObject
    {
        public int intMember;
        public string stringMember;
        public string nullMember;
        public BindingObject(int i, string str1, string str2)
        {
            intMember = i;
            stringMember = str1;
            nullMember = str2;
        }
    } 
    ////Somewhere
    ArrayList list = new ArrayList();
    list.Add(new BindingObject(1, "One", null));
    list.Add(new BindingObject(2, "Two", null));
    list.Add(new BindingObject(3, "Three", null));
    dataGrid1.DataSource = list;
