    public static class MyClass
    {
        public static object myValue;
    }
    private void label14_Click(object sender, EventArgs e)
    {
        frmSelectInvoice selectInvoice = new frmSelectInvoice();
        selectInvoice.ShowDialog();  
        //Get value before close
        object value = MyClass.myValue;
    }
    
    public partial class frmSelectInvoice : DevExpress.XtraEditors.XtraForm
    {
        public ValinorEntities valinor;
        public BindingSource src;
    
        public frmSelectInvoice()
        {
            InitializeComponent();
    
            using (this.valinor = new ValinorEntities())
            {
                this.valinor = new ValinorEntities();
                this.src = new BindingSource(valinor.invoices_head, null);
                gridControl1.DataSource = src;
                src.DataSource = valinor.invoices_head;
            }
        }
    private void button1_Click(object sender, EventArgs e)
    {
        //Set value after close
        MyClass.myValue = "value";
        this.Close();       
    }
}
