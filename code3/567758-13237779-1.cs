         public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
        
                    CreatePanels();
                }
        
                private void CreatePanels()
                {
    
    //YOu should create panelGlobal on your winform and set DockStyle.Fill
                     panelGlobal.Controls.Add(CreatePanel("topPanel",DockStyle.Top,Color.Red));
                     panelGlobal.Controls.Add(CreatePanel("bottomPAnel", DockStyle.Bottom, Color.Gray));
                    panelGlobal.Controls.Add(CreatePanel("fillPanel",DockStyle.Fill,Color.Snow));
                }
        
                private Panel CreatePanel(string panelName, DockStyle dockStyle,Color color)
                {
                    return new Panel() { Name = panelName, Dock = dockStyle , BackColor=color};
                }
            }
