    class Cell : Label
        {
        
        public Cell(Form form)
            {
               
                    this.Parent = form;        
                this.Height = 30;
                this.Width = 30;
            }
        } 
        
        
        public partial class Form1 : Form
        { 
            Label label = new Label();
        
        
            public Form1()
            {
                InitializeComponent();
        
        
                Cell cell = new Cell(this);
        
                cell.Location = new Point(150, 150);   //this doesnt work
        
                label.Location = new Point(150,150);   //but this does
        
            }
