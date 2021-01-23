    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                //Create a listbox, with given height/width and top/left
                var lstBox = new ListBox
                {
                    Width = 300,
                    Height = 300,
                    Top = 10,
                    Left = 10
                };
    
                //Add the listbox to your form
                this.Controls.Add(lstBox);
    
                //Create a list of your customclass
                var listCustomClass = new List<CustomClass>();
    
                //Populate the list with values
                for (int i = 0; i < 50; i++)
                {
                    //create an instanze of your customclass
                    var customClass = new CustomClass();
    
                    //set properties of your class
                    customClass.Name = "Name " + i;
                    customClass.Description = "Description " + i;
                    
                    if (i % 2 == 0)
                        customClass.MethodName = "CallMeBaby";
                    else
                        customClass.MethodName = "CallMeBabyWithParameter";
    
                    customClass.RandomProperty1 = "RandomProperty1 " + i;
    
                    //add the newly created customclass into your list
                    listCustomClass.Add(customClass);
                }
    
                //set the listbox to display or value what you need
                lstBox.DisplayMember = "Description"; //Name of a property inside the class CustomClass
                lstBox.ValueMember = "Name"; //Name of a property inside the class CustomClass
    
                //set the datasource
                lstBox.DataSource = listCustomClass;
    
                //register the selectedindexchanged event
                lstBox.SelectedIndexChanged += lstBox_SelectedIndexChanged;
            }
    
            private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                //get the listbox from the sender
                var lstBox = (sender as ListBox);
    
                if (lstBox != null)
                {
                    //safe cast the selecteditem to your customclass to get full access to any public property with the class definition
                    var customClass = lstBox.SelectedItem as CustomClass;
    
                    if (customClass != null)
                    {
                        //do what ever you want with the object and its properties
                        var name = customClass.Name;
                        var desription = customClass.Description;
                        var methodName = customClass.MethodName;
                        var randomProperty1 = customClass.RandomProperty1;
    
                        //call a certain method based on a string within the object
                        if (methodName == "CallMeBaby")
                            CallMeBaby();
                        else if (methodName == "CallMeBabyWithParameter")
                            CallMeBaby(name);
                    }
                }
            }
    
            //declare the methods that are being called
            private void CallMeBaby(string value)
            {
                //Access the parameter and do something
                if (value == "HelloWorld!")
                {
                    //Do something...
                }
            }
    
            //parameterless method to show the possibilities...
            private void CallMeBaby()
            {
                //Do something...
            }
    
    
            //define a public class
            public class CustomClass
            {
                //random properties, can be extended to have what ever your need 
                public string Name { get; set; }
                public string Description { get; set; }
                public string MethodName { get; set; }
                public string RandomProperty1 { get; set; }
            }
        }
