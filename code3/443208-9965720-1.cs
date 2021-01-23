    public partial class Form2 : Form
    {
        private readonly db _mydb;
        public Form2(db mydb)
        {
            _mydb = mydb;
        }
   
        void function()
        {
            _mydb.func("some parameter");
        }
    }
