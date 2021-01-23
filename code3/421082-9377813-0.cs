    public class GradientPanel : Panel {
      private Color ColorA = Color.LightBlue;
      private Color ColorB = Color.Red;
      private LinearGradientMode GradientFillStyle = LinearGradientMode.ForwardDiagonal;
      public GradientPanel() {
        DoubleBuffered = true;
        ResizeRedraw = true;
      }
      public Color colourStart {
        get { return ColorA; }
        set { ColorA = value; Invalidate(); }
      }
      public Color colourEnd {
        get { return ColorB; }
        set { ColorB = value; Invalidate(); }
      }
      public LinearGradientMode colourGradientStyle {
        get { return GradientFillStyle; }
        set { GradientFillStyle = value; Invalidate(); }
      }
      protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e) {
        using (var gradientBrush = new LinearGradientBrush(ClientRectangle, ColorA, ColorB, GradientFillStyle)) {
          e.Graphics.FillRectangle(gradientBrush, ClientRectangle);
        }
      }
    }
