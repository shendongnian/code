    interface IAddValues
    {
        void AddValue(string value);
    }
    class Form1: IAddValues
    {
        // ...
        public void AddValue(string value)
        {
             // ...
        }
    }
        // somewhere in form1:
        var form2 = new Form2(this as IAddValues);
        form2.Show();
       
