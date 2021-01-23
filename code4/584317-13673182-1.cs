    public class MyButton : Button
    {
      protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
      {
        throw new Exception("my test exception");
      }
    }
