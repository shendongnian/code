        XElement x;
        public Form1()
        {
            InitializeComponent();
            x = XElement.Load("In.xml");
            comboBox1.Items.AddRange(
                 x.Elements("a")
                  .Select(a => a.Attribute("name").Value)
                  .ToArray());
            comboBox1.SelectedIndexChanged += new EventHandler((s, e) =>
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedIndex > -1)
                {
                    comboBox2.Items.AddRange(
                        x.Elements("a")
                         .First(a => a.Attribute("name")
                                      .Value
                                      .Equals(comboBox1.SelectedItem))
                         .Elements()
                         .Select(b => b.Value)
                         .ToArray());
                }
            });
        }
        
