        [DefaultValueAttribute("Contact Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Contact))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(System.String) && value is Contact)
            {
                Contact contact = value as Contact;
                return string.Format("Name: {0} - Address: {1}", contact.Name, contact.Address);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    [TypeConverter(typeof(Contact2))]
    [DescriptionAttribute("Expand to see the spelling options for the application.")]
    class Contact2 : ExpandableObjectConverter
    {
        private Contact contato1;
        public Contact Contato1
        {
            get
            {
                return contato1;
            }
            set
            {
                contato1 = value;
            }
        }
        private Contact contato3;
        public Contact Contato3
        {
            get
            {
                return contato3;
            }
            set
            {
                contato3 = value;
            }
        }
        public Contact2()
        {
            this.contato1 = new Contact()
            {
                Address = "Add1",
                Name = "Name1"
            };
            this.contato3 = new Contact()
            {
                Address = "Add3",
                Name = "Name3"
            };
        }
    }
    public partial class Form2 : Form
    {
        PropertiesList<Contact> listContact = new PropertiesList<Contact>();
        //List<Contact> listContact = new List<Contact>();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listContact.Clear();
            Contact newContact = null;
            newContact = new Contact();
            newContact.Name = "diana";
            newContact.Address = "en";
            listContact.Add(newContact);
            newContact = null;
            newContact = new Contact();
            newContact.Name = "maxim";
            newContact.Address = "cand";
            listContact.Add(newContact);
            propGrid.AllowDrop = true;
            object[] itens = new object[2];
            itens[0] = listContact;
            itens[1] = newContact;
            propGrid.SelectedObject = listContact;
            this.Controls.Add(propGrid);
            propGrid.Dock = DockStyle.Fill;
        }
    }
    [TypeConverter(typeof(Contact))]
    class PropertiesList<T> : ExpandableObjectConverter where T : Contact
    {
        private List<T> innerList = new List<T>();
        public List<string> Names
        {
            get
            {
                List<string> valuesReturned = null;
                if (innerList.Count > 0)
                {
                    valuesReturned = new List<string>();
                    for (int i = 0; i < innerList.Count; i++)
                    {
                        valuesReturned.Add(innerList[i].Name);
                    }
                }
                return valuesReturned;
            }
        }
        public List<T> Item
        {
            get
            {
                List<T> valuesReturned = null;
                if (innerList.Count > 0)
                {
                    valuesReturned = new List<T>();
                    for (int i = 0; i < innerList.Count; i++)
                    {
                        valuesReturned.Add(innerList[i]);
                    }
                }
                return valuesReturned;
            }
        }
        public Color GetColors { get; set; }
        public Contact2 Contato22
        {
            get
            {
                return new Contact2();
            }
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Contact))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(System.String) && value is Contact)
            {
                Contact contact = value as Contact;
                return string.Format("Name: {0} - Address: {1}", contact.Name, contact.Address);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        #region Simulate List
        public void Add(T item)
        {
            innerList.Add(item);
        }
        public void Clear()
        {
            innerList.Clear();
        }
        #endregion
    }
