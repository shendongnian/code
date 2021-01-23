    using System.Diagnostics;
    using System.Windows.Forms;
    namespace WindowsFormsApplication13
    {
        public partial class Form1 : Form
        {
            public Form1()
	    {
	        InitializeComponent();
	    }
	    private void Form1_Load(object sender, System.EventArgs e)
	    {
	        // Add a link to the LinkLabel.
	        LinkLabel.Link link = new LinkLabel.Link();
	        link.LinkData = "http://www.dotnetperls.com/";
	        linkLabel1.Links.Add(link);
	    }
	    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	    {
	        // Send the URL to the operating system.
	        Process.Start(e.Link.LinkData as string);
	    }
        }
    }
