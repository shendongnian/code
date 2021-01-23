    List<int> myList = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < 10; i++)
                    myList.Add(i);
            }
        }
        protected void btn_AddItem_Click(object sender, EventArgs e)
        {
            myList.Add(10);
            Console.Write(myList.Count()); //always prints "1"
        }
