       private DataGridViewRow row;
       private User userObj;
    
    public OrderSearchForm(User user)
    {
        this.userObj=user;
    
    } 
    
    
        public DataGridViewRow Row
        {
            get { return row; }
            set { row = value; }
        }
    
        private void OrderSearchForm_Load(object sender, EventArgs e)
        {
           //Do Operation with User's Properties.as you Like
    
            OrderSearchgridview.Rows.Add(r);
        }
