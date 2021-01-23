    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            Element element = new Element();
            element.Property = "Soft";
            element.Metal = true;
            element.Name = "Gold";
            listBox1.Items.Add(element);
            element = new Element();
            element.Property = "Indestructible";
            element.Metal = true;
            element.Name = "Adamantium";
            listBox1.Items.Add(element);
            element = new Element();
            element.Property = "Liquid";
            element.Metal = true;
            element.Name = "Mercury";
            listBox1.Items.Add(element);
            element = new Element();
            element.Property = "Fluffy";
            element.Metal = false;
            element.Name = "Kitten";
            listBox1.Items.Add(element);
        }
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Element element = (Element)listBox1.SelectedItem;
                label1.Text = "Property: " + element.Property;
                label2.Text = "Metal: " + element.Metal.ToString();
            }
        }
    }
    public class Element
    {
        public string Property;
        public bool Metal;
        public string Name;
        public override string ToString()
        {
            return Name;
        }
    }
