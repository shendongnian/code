     public Edit_Details(Student student)
        {
            InitializeComponent();
            nameLabel.Text = student.Forename;
            savebutton.Click+=(sender,e)=>
              {
                 savebutton.Text=student.ChangeName(editNameTextBox.Text);
              };
        }
