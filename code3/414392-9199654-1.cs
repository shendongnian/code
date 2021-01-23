     public event PaintEventHandler OnPaint;
     public GMap()
     {
       InitializeComponent();
       this.Paint += new PaintEventHandler(GMap_Paint);
     }
     void Gmap_Paint(object sender, PaintEventArgs e)
     {
         OnPaint(this, e);
     }
