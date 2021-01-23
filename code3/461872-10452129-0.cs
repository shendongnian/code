        private void BindPerson()
        {
            Person p2 = new Person();
            p2.PersonType = "Person2";
            Person p3 = new Person();
            p3.PersonType = "Person3";
            ListItem person2ListItem = new ListItem();
            person2.Text = p2.PersonType;
            person2.Value = p2.PersonType;
            listBox.Items.Add(person2ListItem);
            ListItem person3ListItem = new ListItem();
            person3.Text = p3.PersonType;
            person3.Value = p3.PersonType;
            person3.Selected = true; // This will make it selected
            listBox.Items.Add(person3ListItem);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPerson();
            }
        }
