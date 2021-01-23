    public partial class Form1 : Form
    {
        int[] panelLocations;
        Point[] pointLocations;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panelLocations = new int[5];
            pointLocations = new Point[5];
            panelLocations[1] = 1;
            panelLocations[2] = 2;
            panelLocations[3] = 3;
            pointLocations[1] = new Point(panel1.Left, panel1.Top); //Top
            pointLocations[2] = new Point(panel2.Left, panel2.Top);
            pointLocations[3] = new Point(panel3.Left, panel3.Top); //Bottom
        }
        private void relocate(int curPanel, bool goTop)
        {
            int curLoc = panelLocations[curPanel];
            int newLoc = curLoc - 1;
            if (!goTop)
            {
                newLoc = curLoc + 1;
            }
            if (newLoc < 1) newLoc = 3;
            if (newLoc > 3) newLoc = 1;
            if (newLoc != curLoc)
            {
                int otherIndex = Array.IndexOf(panelLocations, newLoc);
                panelLocations[curPanel] = newLoc;
                relocatePanel(curPanel);
                
                panelLocations[otherIndex] = curLoc;
                relocatePanel(otherIndex);
            }
        }
        private void relocatePanel(int curIndex)
        {
            if (curIndex == 1)
            {
                panel1.Location = pointLocations[panelLocations[1]];
            }
            else if (curIndex == 2)
            {
                panel2.Location = pointLocations[panelLocations[2]];
            }
            else if (curIndex == 3)
            {
                panel3.Location = pointLocations[panelLocations[3]];
            }
        }
        private void buttonTop1_Click(object sender, EventArgs e)
        {
            relocate(1, true);
        }
        private void buttonBottom1_Click(object sender, EventArgs e)
        {
            relocate(1, false);
        }
    }
