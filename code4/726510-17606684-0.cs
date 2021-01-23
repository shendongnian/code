    public class Cube : Panel {
       public Cube(){
          Selected = false;
       }
       protected override void OnPaint(PaintEventArgs e){
          //Draw your background to make it look like selected first before drawing string on top.
          if(Selected) e.Graphics.FillRectangle(Brushes.Green, ClientRectangle);
          //Draw your string normally as you did here
          //.......
       }
       public bool Selected { get; set;}
       public void Select(){
          Selected = true;
          Invalidate();
       }
       public void Deselect(){
          Selected = false;
          Invalidate();
       }
    }
    //use the code
    yourCube.Select();//select a cube
    yourCube.Deselect();//deselect a cube
