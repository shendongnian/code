    public class Edit
    {
        public int val = 0;
        public Edit(int a)
        {
            val = a; 
            InitializeComponent();
        }
        public void Edit_Load()
        {
          txtbox.Text = val.ToString();
        }
    }
