     public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
    
            public bool _checkBoxProperty
            {
                get
                {
                    if (usercontrolbrowser.Document != null)
                    {
                        return Convert.ToBoolean(usercontrolbrowser.Document.GetElementById("Checkbox1").GetAttribute("checked"));
                    }
                    else
                    {
                        return false;//error
                    }
                }
    
                set
                {
                    if (usercontrolbrowser.Document != null)
                    {
                        usercontrolbrowser.Document.GetElementById("Checkbox1").SetAttribute("checked", value.ToString());
                    }
                }
            }
            public void DocHtml(string dochtml)
            {
                usercontrolbrowser.DocumentText = dochtml;
            }
    
        }
